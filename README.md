# Unity Project Bootstrap

[![GitHub](https://img.shields.io/github/license/SBUplakankus/unity-project-bootstrapper)](LICENSE)
[![GitHub release](https://img.shields.io/github/v/release/SBUplakankus/unity-project-bootstrapper)](https://github.com/SBUplakankus/unity-project-bootstrapper/releases)
[![GitHub issues](https://img.shields.io/github/issues/SBUplakankus/unity-project-bootstrapper)](https://github.com/SBUplakankus/unity-project-bootstrapper/issues)
[![GitHub stars](https://img.shields.io/github/stars/SBUplakankus/unity-project-bootstrapper?style=social)](https://github.com/SBUplakankus/unity-project-bootstrapper/stargazers)

A lightweight Unity Editor tool that automates creation of a clean, professional **project folder structure** with one click.

The tool is editor-only, adds no runtime dependencies, and safely generates folders without overwriting existing content.

---

## Installation

### Via Unity Package Manager (From Git URL)

1. Open Unity Editor
2. Go to **Window → Package Manager**
3. Click the **+** button in the top-left corner
4. Select **Add package from git URL...**
5. Enter:

   ```
   https://github.com/SBUplakankus/unity-project-bootstrapper.git
   ```
6. Click **Add**

---

## Features

* **One-click project setup** – Generate a full folder structure instantly
* **Preset-based layouts** – Minimal, Standard, Complete, and Game Jam presets
* **Granular control** – Toggle individual folders on or off
* **Industry-standard organization** – Proven production-ready structure
* **Safe execution** – Never overwrites existing folders
* **Git-friendly** – Optional `.gitkeep` and `.gitignore` helpers
* **Unity-aware warnings** – Highlights special folders like `Resources`
* **Undo support** – Folder creation is fully undoable
* **Editor-only** – No runtime code or dependencies

---

## Example Output

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

*Note: Only folders (and optional helper files) are created. No assets are modified.*

---

## Usage

1. Open Unity
2. Navigate to `Tools > Professional Folder Generator`
3. In the window that appears:

   * **Select a preset** or manually toggle folders
   * **Configure options** such as README or `.gitkeep` generation
   * **Click “Generate Folder Structure”**

All folders are created immediately. Existing folders are preserved.

---

## Presets

* **Minimal** – Core folders only, ideal for prototypes
* **Standard (Recommended)** – Balanced setup for most projects
* **Complete** – All available folders enabled
* **Game Jam** – Lightweight structure for rapid iteration

---

## Optional Folders

* Animations
* Shaders
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

Some folders have special behavior in Unity and should be used intentionally:

* **Resources** – Runtime-loaded assets (warning generated)
* **StreamingAssets** – Direct file access at runtime
* **Gizmos** – Custom scene view icons

---

## Technical Details

* **Editor-Only** – All scripts live in an `Editor` context
* **No Dependencies** – Uses only Unity’s built-in APIs
* **Undo Support** – Registered through Unity’s Undo system
* **Non-destructive** – Existing folders are never replaced
* **Version-control friendly** – Designed for team workflows

---

## Architecture

```
ProjectBootstrap/
├── ProjectBootstrap.cs          Editor window (UI only)
├── FolderCreator.cs             Folder creation logic
├── FolderGeneratorSettings.cs   Presets and user configuration
├── FolderStructureData.cs       Folder definitions and metadata
├── FileGenerator.cs             README and helper file generation
└── FolderPreset.cs              Preset enumeration
```

**Separation of concerns is strictly enforced** to keep the tool maintainable and extensible.

---

## Customization

The tool is intentionally simple to extend.

### Adding a New Folder

1. Add a setting in `FolderGeneratorSettings.cs`
2. Define metadata in `FolderStructureData.cs`
3. Add creation logic in `FolderCreator.cs`
4. Expose the option in the editor UI

### Adding a New Preset

1. Add a value to `FolderPreset.cs`
2. Define its configuration in `FolderGeneratorSettings.cs`
3. Add a description in `GetPresetDescription()`

---

## Best Practices

* Start with the **Standard** preset and refine as needed
* Keep first-party assets separated from third-party content
* Avoid `Resources` unless explicitly required
* Enable `.gitkeep` files for team-based repositories
* Isolate imported assets inside `_ThirdParty`

---

## Contributing

This tool is designed to be small, readable, and easy to modify.

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push the branch
5. Open a pull request

Bug fixes and quality-of-life improvements are especially welcome.

---

## License

MIT License. See the `LICENSE` file for details.

---

## Support

For issues or questions:

1. Check the source code comments
2. Ensure the scripts are placed in an `Editor` folder
3. Open an issue on GitHub if needed

---

**Note:** This tool creates organizational structures only. It does not enforce architectural patterns or modify existing assets.

---
