
# Unity Professional Folder Generator

A Unity Editor utility that generates consistent, industry-standard folder structures for Unity projects. The tool is designed to reduce initial setup time, enforce organizational consistency, and support scalable project development.

The tool is editor-only, does not overwrite existing folders, and integrates cleanly with version control workflows.

---

## Overview

Unity Professional Folder Generator allows teams and individual developers to quickly scaffold a clean project directory using predefined or custom configurations. Folder structures are based on common production practices and can be adapted to suit different project sizes and workflows.

---

## Features

* Preset-based folder generation (Minimal, Standard, Complete, Game Jam)
* Granular control over individual folders
* Industry-standard asset organization
* Optional auto-generated README files
* Git-friendly folder tracking via `.gitkeep`
* Optional `.gitignore` helpers for third-party content
* Warnings for Unity special-purpose folders (e.g. `Resources`)
* Full Undo/Redo support via Unity’s Undo system
* Safe execution with no overwriting of existing folders
* Modular, maintainable code architecture

---

## Installation

### Option 1: Unity Package Manager (Git URL)

1. Open Unity
2. Navigate to **Window → Package Manager**
3. Click the **+** button
4. Select **Add package from git URL…**
5. Enter:

   ```
   https://github.com/yourusername/unity-folder-generator.git
   ```
   
---

### Included Files

* `ProjectBootstrap.cs` — Editor window and UI
* `FolderCreator.cs` — Folder generation logic
* `FolderGeneratorSettings.cs` — User settings and preset configuration
* `FolderStructureData.cs` — Folder definitions and descriptions
* `FileGenerator.cs` — File and documentation generation utilities
* `FolderPreset.cs` — Preset definitions

---

## Usage

1. Open Unity
2. Navigate to **Tools → Professional Folder Generator**
3. Select a preset or manually configure folders
4. Click **Generate Folder Structure**

All folders are created immediately. Existing folders are preserved.

---

## Architecture

The project follows a clear separation of concerns to ensure maintainability and extensibility.

```
ProjectBootstrap/
├── ProjectBootstrap.cs          Editor window (UI only)
├── FolderCreator.cs             Folder creation logic
├── FolderGeneratorSettings.cs   Configuration and presets
├── FolderStructureData.cs       Folder definitions and metadata
├── FileGenerator.cs             File creation utilities
└── FolderPreset.cs              Preset enumeration
```

### Responsibilities

**ProjectBootstrap.cs**

* Renders the editor interface
* Collects user input
* Delegates execution to core logic

**FolderCreator.cs**

* Executes folder creation
* Manages generation workflow
* Tracks created assets

**FolderGeneratorSettings.cs**

* Stores user preferences
* Applies preset configurations
* Provides preset metadata

**FolderStructureData.cs**

* Defines folder hierarchies
* Stores folder descriptions
* Provides documentation templates

**FileGenerator.cs**

* Creates `.gitkeep` files
* Generates README files
* Generates warning files for special folders

**FolderPreset.cs**

* Defines available presets

---

## Default Folder Structure

### Core Folders

```
Assets/
├── Scripts/
│   ├── Gameplay/
│   ├── UI/
│   ├── Managers/
│   ├── Utilities/
│   ├── ScriptableObjects/
│   └── Data/
├── Art/
│   ├── Textures/
│   ├── Models/
│   ├── Materials/
│   └── Sprites/
├── Prefabs/
│   ├── Characters/
│   ├── Environment/
│   ├── UI/
│   └── Effects/
├── Audio/
│   ├── Music/
│   ├── SFX/
│   ├── Voices/
│   └── Mixers/
└── Scenes/
    ├── Development/
    └── Production/
```

---

## Optional Folders

* Shaders
* Animations
* Data
* Settings
* Editor
* Localization
* Documentation
* Tests
* Plugins
* `_ThirdParty`

---

## Unity Special Folders

The following folders have special behavior in Unity and should be used deliberately:

* `Resources` — Runtime-loaded assets (warning generated)
* `StreamingAssets` — Files accessed directly at runtime
* `Gizmos` — Custom scene view icons

---

## Presets

**Minimal**
Core folders only. Intended for prototypes and small experiments.

**Standard (Recommended)**
Balanced configuration suitable for most projects.

**Complete**
All available folders enabled. Intended for large or long-term projects.

**Game Jam**
Lightweight structure optimized for rapid iteration.

---

## Best Practices

* Start with the Standard preset and adjust as needed
* Use a project root folder to separate first-party assets from packages
* Avoid `Resources` unless explicitly required; prefer Addressables
* Enable `.gitkeep` files for team-based projects
* Isolate third-party assets in `_ThirdParty`

---

## Extending the Tool

### Adding a New Optional Folder

1. Add a setting in `FolderGeneratorSettings.cs`
2. Add folder metadata in `FolderStructureData.cs`
3. Add creation logic in `FolderCreator.cs`
4. Add a toggle to the editor UI

### Adding a New Preset

1. Add a new value to `FolderPreset.cs`
2. Define preset configuration in `FolderGeneratorSettings.cs`
3. Add a description in `GetPresetDescription()`

---

## Contributing

Contributions are welcome.

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push the branch
5. Open a pull request

---

## Changelog

### v1.0.0 (2026)

* Initial release
* Preset-based folder generation
* Customizable folder selection
* Git integration
* Unity special folder support
* Undo/Redo support

---

## License

MIT License. See the LICENSE file for details.

---

## Support

* Issues: GitHub Issues
* Discussions: GitHub Discussions

