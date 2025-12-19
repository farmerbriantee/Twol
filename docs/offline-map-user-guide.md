# Offline Map User Guide

This guide explains how to download, manage, and use offline satellite imagery in Twol.

## Overview

Twol allows you to download satellite imagery for your fields once and use it offline forever. This eliminates the need for continuous internet connection while working in the field.

**Benefits:**
- Download once, use forever
- No internet required after initial download
- Fast loading (local disk read vs. internet download)
- High resolution imagery (up to ~1 meter/pixel)

---

## Accessing the Offline Map Feature

### From the Boundary Editor (FormMap)

1. Open the **Boundary Editor** from the main screen
2. Look for the **Offline Map** button in the right panel
3. The button icon indicates the current state:
   - **Green icon (MappingOn)**: Satellite imagery is downloaded and available
   - **Gray icon (MappingOff)**: No satellite imagery downloaded yet

![Offline Map Button Location](images/offline-map-button.png)

---

## Downloading Satellite Imagery

### Prerequisites

- **Field boundary must exist**: You need to create at least one boundary before downloading
- **Internet connection**: Required only for the initial download

### Steps to Download

1. Click the **Offline Map** button in the Boundary Editor
2. The **Download Satellite Imagery** form opens
3. Review the information displayed:
   - **Field name**: Current field
   - **Bounds**: GPS coordinates covered
   - **Resolution**: Select your preferred zoom level
   - **Tiles**: Number of tiles to download
   - **Estimated Size**: Approximate file size

4. Select your preferred **Resolution**:
   | Level | Resolution | Best For |
   |-------|------------|----------|
   | Level 16 - Low | ~4 m/pixel | Large fields, faster download |
   | Level 17 - Medium | ~2 m/pixel | Balanced quality/size |
   | Level 18 - High | ~1 m/pixel | Best detail, larger file |

5. Click **Download** to start
6. Wait for the download to complete (progress bar shows status)
7. Once complete, the imagery is automatically loaded

### Download Form Layout

```
+--------------------------------------------------+
|  Download Satellite Imagery                       |
+--------------------------------------------------+
|  Field: MyField                                   |
|  Bounds: 47.123°N - 47.145°N / 2.345°E - 2.367°E |
|  Resolution: [Level 18 - High (~1m/pixel)]       |
|  Tiles: 234 tiles    Est. Size: ~7.0 MB          |
|  Detail: ~1.19 m/pixel                           |
+--------------------------------------------------+
|  [=================>        ] 67%                 |
|  Downloading tile 156/234...                      |
+--------------------------------------------------+
|  [ Download ]              [ Close ]              |
+--------------------------------------------------+
```

---

## Managing Existing Imagery

When satellite imagery already exists for a field, the form changes to **Manage Satellite Imagery** mode.

### Form Layout (Existing Imagery)

```
+--------------------------------------------------+
|  Manage Satellite Imagery                         |
+--------------------------------------------------+
|  Field: MyField                                   |
|  Bounds: 47.123°N - 47.145°N / 2.345°E - 2.367°E |
|  Resolution: [Level 18 - High (~1m/pixel)]       |
|  Tiles: 234 tiles    Est. Size: ~7.0 MB          |
|  Detail: ~1.19 m/pixel                           |
+--------------------------------------------------+
|  CURRENT IMAGERY                                  |
|  Status: Downloaded    Size: 6.8 MB               |
+--------------------------------------------------+
|  Satellite imagery is available for this field    |
+--------------------------------------------------+
|  [Re-download]  [ Delete ]  [ Close ]             |
+--------------------------------------------------+
```

### Available Actions

| Button | Action |
|--------|--------|
| **Re-download** | Download new imagery (replaces existing) |
| **Delete** | Remove the satellite imagery file |
| **Close** | Close the form without changes |

### Re-downloading Imagery

Use this when:
- You want a different resolution
- The imagery appears outdated
- You expanded your field boundaries

**Note**: The existing file will be deleted before downloading the new one.

### Deleting Imagery

Use this when:
- You want to free up disk space
- The field is no longer in use
- You want to switch back to online tiles

**Warning**: This action cannot be undone. You will need internet access to download again.

---

## Button Icon States

The **Offline Map** button in the Boundary Editor provides visual feedback:

| Icon | State | Description |
|------|-------|-------------|
| ![MappingOn](../SourceCode/Twol/btnImages/MappingOn.png) | **Available** | Satellite imagery is downloaded and ready |
| ![MappingOff](../SourceCode/Twol/btnImages/MappingOff.png) | **Not Available** | No satellite imagery for this field |

The icon updates automatically after:
- Downloading new imagery
- Deleting existing imagery
- Opening the Boundary Editor

---

## File Storage

Satellite imagery is stored as a GeoTIFF file in your field folder:

```
C:\Users\[Username]\Documents\AOG\Fields\[FieldName]\satellite.tif
```

### File Characteristics

- **Format**: GeoTIFF with geographic metadata
- **Size**: Varies by field size and resolution (typically 2-50 MB)
- **Bands**: RGB (3 channels)
- **Georeferencing**: WGS84 (EPSG:4326)

---

## Troubleshooting

### "No Boundaries" Error

**Problem**: The Offline Map button shows an error about missing boundaries.

**Solution**: Create at least one field boundary before downloading satellite imagery.

### "No Internet" Error

**Problem**: Cannot download imagery without internet connection.

**Solution**:
- Connect to the internet to download
- If managing existing imagery (delete), this works offline

### Download Fails or Incomplete

**Problem**: Download stops before completing.

**Possible causes**:
- Internet connection lost
- ESRI server temporarily unavailable
- Disk space full

**Solution**:
- Check internet connection
- Try again later
- Check available disk space

### Imagery Not Showing

**Problem**: Downloaded imagery but field still shows green background.

**Possible causes**:
- GeoTIFF failed to load
- File corrupted during download

**Solution**:
1. Open Offline Map management
2. Delete the existing imagery
3. Download again

### File Locked Error

**Problem**: "Cannot delete existing file" when re-downloading.

**Solution**: This should be handled automatically. If it persists:
1. Close and reopen the Boundary Editor
2. Try again

---

## Data Source

Satellite imagery is sourced from **ESRI World Imagery** service:
- High-resolution aerial and satellite imagery
- Global coverage
- Regularly updated (varies by region)
- Free for non-commercial use

**Note**: Some rural areas may have limited high-resolution coverage at zoom level 18. If imagery appears blurry, try downloading at zoom level 17.

---

## Best Practices

1. **Download before going to the field**: Ensure imagery is ready before you lose internet access

2. **Choose appropriate resolution**:
   - Large fields (>100 ha): Level 17 recommended
   - Small fields (<50 ha): Level 18 for best detail

3. **Backup your data**: The satellite.tif file can be backed up with your field data

4. **Check file size**: Review estimated size before downloading on limited data connections

5. **Update periodically**: Re-download imagery if your field boundaries change significantly
