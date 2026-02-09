# Contributing to Unity Professional Folder Generator

Thank you for your interest in contributing! This document provides guidelines for contributing to this project.

## How to Contribute

### Reporting Bugs

1. **Check existing issues** - Search the [issue tracker](https://github.com/yourusername/unity-folder-generator/issues) to see if the bug has already been reported
2. **Create a new issue** - If not found, create a new issue with:
   - Clear, descriptive title
   - Unity version
   - Steps to reproduce
   - Expected vs actual behavior
   - Screenshots if applicable

### Suggesting Features

1. **Check existing requests** - Look through existing issues and discussions
2. **Create a feature request** - Include:
   - Clear use case
   - How it would improve the tool
   - Any implementation ideas

### Pull Requests

1. **Fork the repository**
2. **Create a feature branch** from `main`
   ```bash
   git checkout -b feature/your-feature-name
   ```
3. **Make your changes**
   - Follow the existing code style
   - Add comments for complex logic
   - Keep changes focused and atomic
4. **Test thoroughly** in Unity
   - Test with different Unity versions if possible
   - Verify all presets work correctly
   - Check edge cases
5. **Update documentation** if needed
   - README.md
   - CHANGELOG.md
   - Code comments
6. **Commit with clear messages**
   ```bash
   git commit -m "Add: Feature description"
   git commit -m "Fix: Bug description"
   git commit -m "Docs: Documentation update"
   ```
7. **Push to your fork**
   ```bash
   git push origin feature/your-feature-name
   ```
8. **Create a Pull Request**
   - Reference any related issues
   - Describe what changed and why
   - Include screenshots for UI changes

## Code Style Guidelines

### C# Conventions
- Follow Unity's C# coding conventions
- Use meaningful variable and method names
- Add XML documentation comments for public methods
- Keep methods focused and concise
- Use regions to organize code sections

### Editor Window Guidelines
- All UI should be intuitive and self-documenting
- Use tooltips for non-obvious options
- Group related settings together
- Maintain consistent spacing and layout
- Test UI at different window sizes

### Best Practices
- Never overwrite existing folders without user confirmation
- Always provide undo support for destructive operations
- Log warnings for skipped operations
- Validate user input
- Handle exceptions gracefully

## Testing Checklist

Before submitting a PR, verify:

- [ ] Tested in Unity 2019.4 LTS or newer
- [ ] All presets generate correct folder structures
- [ ] Custom configurations work as expected
- [ ] .gitkeep files generate when enabled
- [ ] README files generate with correct content
- [ ] Unity special folders create appropriate warnings
- [ ] Undo/redo works correctly
- [ ] No console errors or warnings
- [ ] UI is responsive and scales properly
- [ ] Code follows style guidelines
- [ ] Documentation is updated

## Project Structure

```
unity-folder-generator/
├── ProfessionalFolderGenerator.cs  # Main tool script
├── README.md                       # Project documentation
├── LICENSE                         # MIT License
├── CHANGELOG.md                    # Version history
├── CONTRIBUTING.md                 # This file
├── package.json                    # UPM package definition
└── .gitignore                      # Git ignore rules
```

## Development Setup

1. Clone the repository
2. Copy `ProfessionalFolderGenerator.cs` to any Unity project's `Assets/Editor` folder
3. Open Unity and the script will compile automatically
4. Access the tool via `Tools > Professional Folder Generator`

## Questions?

Feel free to:
- Open a [Discussion](https://github.com/yourusername/unity-folder-generator/discussions)
- Ask in an issue
- Contact the maintainers

## License

By contributing, you agree that your contributions will be licensed under the MIT License.
