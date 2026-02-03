# Mody+ Video Generator — Long UI Spec (SharpDevelop / WinForms)

This document outlines a **C# WinForms** user interface concept (SharpDevelop style) for preparing Sony Vegas project assets and arranging edits in a YTP/YTPMV-inspired workflow tailored to the **Mody+** channel aesthetic.

> **Note:** This is a planning spec only. It describes layout, data flow, and feature scope for a future implementation.

---

## 1) Project Goals

- Provide a **single desktop UI** for assembling clips, audio, memes, and effect presets.
- Export a **Sony Vegas project folder layout** (organized media bins, markers, and a manifest).
- Keep editing choices consistent with **1990s/2000s/2010s/2020s YTP/YTPMV** styles.
- Prepare metadata for **GitHub release** (README, changelog, credits).

---

## 2) UI Layout Overview (Long Form)

**Main Window:**

- **Left Navigation Panel (dock left)**
  - Project
  - Source Library
  - Remix Engine
  - Effects & Memes
  - Timeline Plan
  - Export / Release

- **Main Workspace (center)**
  - Multi-tab canvas with long-form forms (stacked panels)

- **Preview + Metering (dock right)**
  - Video preview (scrub, loop A/B)
  - Audio meters (peak/RMS)
  - Beat grid and BPM readout

- **Footer**
  - Status log
  - Queue state
  - “Build Manifest” button

---

## 3) Detailed Panels

### 3.1 Project Panel

- Project name
- Base output folder
- Target FPS + resolution
- “Mody+ profile” dropdown:
  - `Mody+ Short`
  - `Mody+ Long`
  - `Mody+ Chaos`

### 3.2 Source Library Panel

- Drag/drop media ingestion
- Auto-tagging:
  - face/character
  - meme types
  - audio style
- Clip rating system (1–5)

### 3.3 Remix Engine Panel

- “Remix Mode” selector
  - Relax
  - Random
  - Fast
  - Loop
  - Music Video
  - Crazy Chaos
- Sliders:
  - Cut Frequency
  - Pitch Shift Range
  - Loop Intensity
  - Glitch Density
  - Sentence Mix Aggression

### 3.4 Effects & Memes Panel

- Preset categories
  - Classic YTP
  - Modern YTPMV
  - Meme SFX
  - 3D Overlay
  - VHS/CRT
  - Datamosh
- Meme slot assignment
  - Hotkeys for common insertions

### 3.5 Timeline Plan Panel

- Section builder
  - Intro → Verse → Bridge → Chaos → Cooldown → Outro
- Beat markers (import from BPM)
- “Vegas marker export” button

### 3.6 Export / Release Panel

- Export target:
  - Vegas project folder
  - Media manifest (CSV/JSON)
  - Credits template (Markdown)
  - GitHub release notes
- Compliance checklist
  - Copyright flags
  - Third-party asset licenses

---

## 4) Output Structure (Proposed)

```
ModyPlus_Project/
  assets/
    video/
    audio/
    images/
  vegas/
    timeline_markers.csv
    bins_manifest.json
  release/
    README.md
    CREDITS.md
    CHANGELOG.md
```

---

## 5) Sony Vegas Integration (Planned)

Since Sony Vegas does not provide a modern scripting API for full project creation, the tool should:

- Generate **marker CSV files** for import.
- Produce a **media manifest** for manual bin setup.
- Create a “helper checklist” for the editor to apply presets.

---

## 6) Mody+ Format Clarification (Open Questions)

To fully implement the workflow, confirm:

- Output resolution and FPS
- Required metadata or title rules
- Preferred watermark or branding
- Exact release format for GitHub

---

## 7) Future Enhancements

- Preset syncing with a shared “Mody+ style pack”
- Beat-driven auto-edit suggestions
- Optional Blender bridge for quick 3D overlays

