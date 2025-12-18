# Satellite Imagery Sources

## Overview

Twol uses satellite imagery for field context display. This document covers source selection and legal considerations.

## Sources

### ESRI World Imagery (GeoTIFF Download)

| Aspect | Detail |
|--------|--------|
| URL | `https://server.arcgisonline.com/ArcGIS/rest/services/World_Imagery/MapServer/tile/{z}/{y}/{x}` |
| Resolution | ~0.5-1m |
| Auth | None required |
| Coverage | Global |

**Terms of Use**
- Visualization: Allowed for non-commercial apps
- Download/Cache: Gray area - tolerated for personal use
- Attribution: "Esri, Maxar, Earthstar Geographics, and the GIS User Community"

### Google Maps (Online Tiles)

| Aspect | Detail |
|--------|--------|
| URL | `http://mt{0-3}.google.com/vt/lyrs=s&hl=en&x={x}&y={y}&z={z}` |
| Auth | None (unofficial endpoint) |
| License | Not authorized without API key |

**Warning**: This endpoint is undocumented and may be blocked. For legal usage, requires Google Cloud API key with Maps Static API.

## Agricultural Use Case

For a farmer using Twol for tractor guidance:

| Question | Answer |
|----------|--------|
| Commercial use? | Technically yes (professional activity) |
| Resale? | No (personal use for farm operation) |
| Request volume? | Low (few fields per farm) |
| Redistribution? | No (stored locally only) |

### Practical Position

Open-source precision agriculture projects (AgOpenGPS, FarmHack) use these sources because:
- Low volume: Few fields, not millions of requests
- No resale: Imagery not redistributed commercially
- Community benefit: Open-source, non-profit projects
- Societal value: Sustainable agriculture, reduced inputs

## Cache Architecture

```
GeoTIFF Mode (recommended)
1. Single download from ESRI
2. Local storage: Fields/{Field}/satellite.tif
3. GDAL read - 100% offline
4. No network requests after initial download

Online Mode (fallback)
1. Requests to Google Maps per visible tile
2. Local cache: TWOL/TexCache/{z}/{x}/{y}.tile
3. Continuous requests if not cached
4. Requires internet connection
```

## Alternatives

| Source | License | Resolution | Cost |
|--------|---------|------------|------|
| Mapbox | API key (50K/month free) | High | Free tier then paid |
| Bing Maps | Similar to Google | High | Free with limits |
| OpenStreetMap | ODbL (libre) | No satellite | Free |
| Sentinel-2 (ESA) | Libre | 10m/pixel | Free |

## Recommendations

**Individual farmer**: Use GeoTIFF mode with ESRI
- Single download per field
- 100% offline after download
- Minimal request volume
- Very low legal risk

**Commercial distribution**: Consider commercial license
- Mapbox commercial plans
- Google Maps Platform with API key
- ESRI ArcGIS Online licenses
- Direct imagery provider licenses (Maxar, Planet)

## References

- [ESRI Terms of Use](https://www.esri.com/en-us/legal/terms/full-master-agreement)
- [Google Maps Platform ToS](https://cloud.google.com/maps-platform/terms)
- [Mapbox ToS](https://www.mapbox.com/legal/tos)
- [OpenStreetMap License](https://www.openstreetmap.org/copyright)
- [Copernicus Sentinel Data Terms](https://sentinel.esa.int/documents/247904/690755/Sentinel_Data_Legal_Notice)
