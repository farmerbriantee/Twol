# Satellite Imagery System - Technical Documentation

## Overview

Twol's satellite imagery system displays satellite images as background to assist field navigation. It supports two operating modes:

1. **GeoTIFF Mode (offline)** - Local imagery downloaded once
2. **Online Mode** - Tiles downloaded on-demand from ESRI

## Architecture

```
┌─────────────────────────────────────────────────────────────────┐
│                        IMAGERY SOURCES                          │
├─────────────────────────────────────────────────────────────────┤
│                                                                 │
│  ┌─────────────────┐          ┌─────────────────┐              │
│  │   GeoTIFF       │          │   ESRI Online   │              │
│  │   (satellite.tif)│          │   (TileServer)  │              │
│  │                 │          │                 │              │
│  │  - Local file   │          │  - Internet     │              │
│  │  - GDAL read    │          │  - Local cache  │              │
│  │  - 100% offline │          │  - Zoom 18      │              │
│  └────────┬────────┘          └────────┬────────┘              │
│           │                            │                        │
│           └──────────┬─────────────────┘                        │
│                      ▼                                          │
│           ┌─────────────────────┐                              │
│           │      Map.cs         │                              │
│           │   (ITileProvider)   │                              │
│           │                     │                              │
│           │  - GeoTiffProvider  │                              │
│           │  - TileServer       │                              │
│           │  - Memory cache     │                              │
│           └──────────┬──────────┘                              │
│                      ▼                                          │
│           ┌─────────────────────┐                              │
│           │   WorldTileMap.cs   │                              │
│           │                     │                              │
│           │  - OpenGL textures  │                              │
│           │  - 7x7 tile grid    │                              │
│           │  - Z-ordering       │                              │
│           └─────────────────────┘                              │
└─────────────────────────────────────────────────────────────────┘
```

## Configuration Settings

### Settings.User.setDisplay_isOnlineTilesOn

| Value | Behavior |
|-------|----------|
| `false` | Solid background only (no GeoTIFF, no online tiles) |
| `true` | Display tiles (GeoTIFF priority if available, otherwise ESRI online) |

### Settings.User.setDisplay_isTextureOn

| Value | Behavior |
|-------|----------|
| `false` | Solid color background (colorFieldDay/colorFieldNight) |
| `true` | Ground texture (z_Floor2.png) |

## Behavior Matrix

| isOnlineTilesOn | GeoTIFF exists | Field open | Result |
|-----------------|----------------|------------|--------|
| OFF | - | No | Solid background |
| OFF | - | Yes | Solid background (GeoTIFF not loaded) |
| ON | No | No | ESRI online tiles |
| ON | No | Yes | ESRI online tiles |
| ON | Yes | Yes | **GeoTIFF** (priority) |

## Loading Flows

### Opening a Field

```
FileOpen() in SaveOpen.Designer.cs
    │
    ├── FileLoadBoundaries()     ─── Load field boundaries
    ├── FileLoadHeadlands()      ─── Load headlands
    ├── FileLoadTrams()          ─── Load tram lines
    │
    └── TryLoadFieldGeoTiff()    ─── GeoTIFF management
            │
            ├── IF isOnlineTilesOn = false
            │       └── Do NOT load GeoTIFF
            │           └── map.UseOnlineTiles()
            │
            └── IF isOnlineTilesOn = true AND satellite.tif exists
                    └── map.LoadGeoTiff(path)
                        ├── GeoTiffProvider loads via GDAL
                        └── _activeProvider = GeoTiffProvider
```

### Closing a Field

```
FileSaveEverythingBeforeClosingField() in SaveOpen.Designer.cs
    │
    └── map.UnloadGeoTiff()
            │
            ├── Dispose GeoTiffProvider
            ├── _activeProvider = null
            ├── Clear tile cache
            └── Force WorldTileMap refresh
                    ├── isUpdateTilesRequired = true
                    └── Reset mapTextureStatus[]
```

### Changing isOnlineTilesOn Setting

```
SaveDisplaySettings() in FormConfig.cs
    │
    ├── Detect value change
    │
    ├── IF OFF → ON (activation)
    │       ├── Look for satellite.tif in field folder
    │       ├── IF exists: map.LoadGeoTiff()
    │       └── Force tiles refresh
    │
    └── IF ON → OFF (deactivation)
            └── map.UnloadGeoTiff()
```

## OpenGL Rendering

### Drawing Order (Z-depth)

```
Z = -0.11  ─── Background (ground texture or solid color)
Z = -0.10  ─── Satellite tiles (GeoTIFF or ESRI)
Z = 0      ─── Boundaries, tracks, vehicle, etc.
```

### WorldTileMap.DrawWorldMap()

```csharp
// 1. Determine if tiles should be displayed
bool shouldShowTiles = mf.map.IsGeoTiffLoaded || Settings.User.setDisplay_isOnlineTilesOn;

// 2. ALWAYS draw background first
GL.Color3(field.R, field.G, field.B);
if (Settings.User.setDisplay_isTextureOn) {
    GL.BindTexture(TextureTarget.Texture2D, Floor);
}
// Draw quad at Z = -0.11

// 3. Draw tiles on top if enabled
if (shouldShowTiles && mapTexture != null) {
    GL.Enable(EnableCap.Blend);  // For GeoTIFF transparency
    // Draw 7x7 tile grid at Z = -0.10
}
```

## Key Files

| File | Role |
|------|------|
| `Mapping/Map.cs` | Main tile manager, cache, providers |
| `Mapping/TileServer.cs` | ESRI online tile download |
| `Mapping/GeoTiffProvider.cs` | GeoTIFF reading via GDAL |
| `Mapping/ESRIDownloader.cs` | GeoTIFF download and assembly |
| `Mapping/WorldTileMap.cs` | OpenGL tile rendering |
| `Forms/SaveOpen.Designer.cs` | Field load/close, TryLoadFieldGeoTiff() |
| `Forms/Settings/FormConfig.cs` | SaveDisplaySettings() |
| `Forms/FormMapDownload.cs` | GeoTIFF download UI |

## ITileProvider Interface

```csharp
public interface ITileProvider
{
    string Name { get; }           // "GeoTIFF Local" or "ESRI World Imagery"
    bool IsAvailable { get; }      // Provider ready for use
    bool RequiresInternet { get; } // true for TileServer, false for GeoTiff
    Image GetTile(int x, int y, int z);  // Get a 256x256 tile
}
```

## File Storage

```
C:\Users\{User}\Documents\TWOL\
├── Fields\
│   └── {FieldName}\
│       ├── Field.txt
│       ├── Boundary.txt
│       └── satellite.tif     ← Field GeoTIFF
│
└── TexCache\                  ← Online tiles cache
    └── {zoom}\
        └── {x}\
            └── {y}.tile
```

## Transparency Handling

GeoTIFF tiles may only cover part of their 256x256 area (field edges). In this case:

1. **GeoTiffProvider** creates tiles with transparent background (Alpha = 0)
2. **WorldTileMap** enables OpenGL blending
3. Background (green/texture) shows through transparent areas

```csharp
// In GeoTiffProvider.ReadRegionAsTile()
pixels[i + 3] = 0;    // Alpha = 0 for areas outside GeoTIFF
pixels[i + 3] = 255;  // Alpha = 255 for GeoTIFF pixels

// In WorldTileMap.DrawWorldMap()
GL.Enable(EnableCap.Blend);
GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
```

## GeoTIFF vs Online Mode Comparison

| Aspect | GeoTIFF | Online (ESRI) |
|--------|---------|---------------|
| Internet | Not required after download | Required |
| Latency | ~5ms (local disk) | ~200ms (network) |
| Storage | 1 file per field (~50-200 MB) | Fragmented cache |
| Resolution | Fixed (download zoom level) | Variable (multi-zoom) |
| Coverage | Field boundaries only | Worldwide |

## Troubleshooting

### Boundaries not appearing
- Check that `bnd.bndList.Count > 0`
- Boundaries are drawn at Z=0, so above the background

### GeoTIFF not loading
- Check `isOnlineTilesOn = true`
- Verify `satellite.tif` exists in field folder
- Check GDAL logs in console

### Black background instead of green
- Blending is not enabled
- Check that `setDisplay_isTextureOn` or background color is correct

### Tiles not refreshing
- Call `worldMap.isUpdateTilesRequired = true`
- Reset `mapTextureStatus[]` to `TexStatus.DefaultLoaded`

## Provider Priority Logic

When `isOnlineTilesOn = true` and a field with `satellite.tif` is open:

1. **GeoTIFF has absolute priority** - No online requests are made
2. Tiles fully covered by GeoTIFF → Pure GeoTIFF tile
3. Tiles partially covered → GeoTIFF with transparent background (green shows through)
4. Tiles outside GeoTIFF bounds → Transparent (green background visible)

When `isOnlineTilesOn = true` and no GeoTIFF exists:
- Online ESRI tiles are used

When `isOnlineTilesOn = false`:
- Only solid green background is displayed
- GeoTIFF is NOT loaded even if it exists
