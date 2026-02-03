# Mody+ Video Generation Tooling Plan (C# WinForms + Sony Vegas)

## Goal
Provide a clear, actionable plan for building a **C# WinForms** desktop UI (SharpDevelop-friendly) that organizes and produces **Mody+ Sony Vegas** edit projects for YTP/YTPMV-style output, then packages deliverables for a GitHub release.

> **Note:** The “Mody+ format” is not defined in the current repo. The plan below assumes a standard Vegas project output (e.g., `.veg`) plus exported media and a reproducible project structure. Adjust the output section once the exact “Mody+ format” is defined.

---

## 1) Product Scope

### Core Capabilities
- **Source Clip Manager**
  - Import Mody+ source videos and automatically categorize by era/style (1990s/2000s/2010s/2020s).
  - Trim and tag clips (e.g., memes, reaction, YTP loop, musical phrase).
- **Edit Recipe Builder**
  - Assemble “edit recipes” that define pacing, remix type (relax/random/faster/loop), and style presets.
  - Apply reusable effect stacks (pitch shift, stutter/loop, glitch, reverse, sentence mixing).
- **Vegas Project Exporter**
  - Generate a Vegas `.veg` project template with media references and timelines for effects.
  - Output a structured folder layout for clips, music, and renders.
- **Release Packager**
  - Produce a GitHub release ZIP containing: `project.veg`, `media/`, `renders/`, and `README.md`.

### Non-Goals (for v1)
- Real-time audio synthesis or full YTPMV automation.
- GPU-heavy 3D compositing (can be scripted in Blender and imported later).

---

## 2) UI Layout (WinForms / SharpDevelop)

### Main Window (Tabbed)
1. **Source**
   - Import list, metadata tags, preview panel.
   - Buttons: *Import*, *Trim*, *Tag*, *Export Clip*.
2. **Recipes**
   - Recipe list with sliders for pace, chaos, and loop intensity.
   - Preset drop-downs for era (90s/00s/10s/20s).
3. **Timeline Prep**
   - Simple track layout preview (audio + video tracks).
   - Drag/drop clip order; optional randomizer.
4. **Export**
   - Output folder selector.
   - Checkboxes: *Generate .veg*, *Create Render Stub*, *Package GitHub Release*.

---

## 3) Data Model (C# POCOs)

```csharp
public class SourceClip {
    public string Path { get; set; }
    public TimeSpan InPoint { get; set; }
    public TimeSpan OutPoint { get; set; }
    public string[] Tags { get; set; }
    public string Era { get; set; } // 90s/00s/10s/20s
}

public class EditRecipe {
    public string Name { get; set; }
    public string RemixStyle { get; set; } // relax/random/faster/loop
    public int ChaosLevel { get; set; } // 0-100
    public int LoopIntensity { get; set; } // 0-100
    public List<string> Effects { get; set; }
}
```

---

## 4) Vegas Integration Strategy

### Practical Approach
- **Template-based**: maintain a base `.veg` file and update clip paths & timestamps via a simple export manifest.
- **Scripting**: Vegas supports scripting (C#) to automate timeline assembly. Use scripts to:
  - Create tracks.
  - Import clips.
  - Apply effects (pitch, reverse, stutter).
  - Arrange clips based on a recipe.

> If Vegas scripting is unavailable in your environment, default to a “manual import” package with a JSON/CSV manifest.

---

## 5) Output Format (Proposed)

```
ModyPlusRelease/
  project.veg
  media/
    clips/
    music/
  renders/
  manifest.json
  README.md
```

`manifest.json` should map:
- clip filename → time range → target track → effect stack

---

## 6) GitHub Release Checklist

- [ ] Export `.veg` project and media folder.
- [ ] Generate `manifest.json` + `README.md`.
- [ ] Zip into `ModyPlusRelease.zip`.
- [ ] Add a short “Build Instructions” section.

---

## 7) Next Clarifications Needed

1. What **exactly** is the “Mody+ format”?
2. Do you want **full automation** (Vegas scripting) or a **manual-friendly** export?
3. Which **YTP/YTPMV effects** are mandatory vs optional?
4. Preferred **audio workflow** (external DAW or Vegas only)?

---

## 8) Suggested Next Steps

1. Define Mody+ output requirements (file types, naming, packaging).
2. Decide on either **Vegas scripting** or **template-based** export.
3. Build the WinForms shell (tabs + data grid + preview panel).
4. Add import/tag/recipe storage (JSON config file).

