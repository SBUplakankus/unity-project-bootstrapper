# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0] - 2024-02-09

### Added
- Initial release of Professional Folder Generator
- 4 preset configurations (Minimal, Standard, Complete, Game Jam)
- Core folder structure with subfolders
  - Scripts (Gameplay, UI, Managers, Utilities, ScriptableObjects, Data)
  - Art (Textures, Models, Materials, Sprites)
  - Prefabs (Characters, Environment, UI, Effects)
  - Audio (Music, SFX, Voices, Mixers)
  - Scenes (Development, Production)
- Optional folders
  - Shaders, Animations, Data, Settings, Editor
  - Localization, Documentation, Tests, Plugins
- Unity special folders support (Resources, StreamingAssets, Gizmos)
- _ThirdParty folder with .gitignore helper
- Automatic .gitkeep file generation
- Automatic README.md generation with folder descriptions
- Resources folder warning system
- Full undo/redo support
- Safe folder creation (never overwrites)
- Comprehensive tooltips and help boxes
- Success dialog with summary
- Scrollable UI for smaller screens
- Professional color-coded generate button

### Documentation
- Comprehensive README with installation instructions
- Best practices guide
- Folder structure documentation
- Preset explanations
- MIT License
- Package.json for Unity Package Manager support

## [Unreleased]

### Planned Features
- Custom preset saving
- Import/export preset configurations
- Folder templates with custom subfolders
- Multi-language support
- Project-specific folder naming conventions
- Integration with popular Unity packages
