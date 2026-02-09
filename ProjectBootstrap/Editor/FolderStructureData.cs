using System.Collections.Generic;

namespace ProjectBootstrap.Editor
{
    /// <summary>
    /// Defines the folder structure and descriptions
    /// </summary>
    public static class FolderStructureData
    {
        /// <summary>
        /// Core folder hierarchy with default subfolders
        /// </summary>
        public static readonly Dictionary<string, List<string>> CoreFolders = new Dictionary<string, List<string>>()
        {
            { "Scripts", new List<string> { "Gameplay", "UI", "Managers", "Utilities", "ScriptableObjects", "Data" } },
            { "Art", new List<string> { "Textures", "Models", "Materials", "Sprites" } },
            { "Prefabs", new List<string> { "Characters", "Environment", "UI", "Effects" } },
            { "Audio", new List<string> { "Music", "SFX", "Voices", "Mixers" } },
            { "Scenes", new List<string> { "Development", "Production" } }
        };

        /// <summary>
        /// Gets a detailed description for a core folder type
        /// </summary>
        /// <param name="folderName">Name of the folder</param>
        /// <returns>Markdown-formatted description with subfolder explanations</returns>
        public static string GetFolderDescription(string folderName)
        {
            switch (folderName)
            {
                case "Scripts":
                    return "C# scripts and code files\n\n" +
                           "**Subfolders:**\n" +
                           "- **Gameplay**: Core game mechanics and logic\n" +
                           "- **UI**: User interface scripts and controllers\n" +
                           "- **Managers**: Singleton managers and system controllers\n" +
                           "- **Utilities**: Helper classes and extensions\n" +
                           "- **ScriptableObjects**: ScriptableObject definitions\n" +
                           "- **Data**: Data structures and containers";

                case "Art":
                    return "Visual assets and artwork\n\n" +
                           "**Subfolders:**\n" +
                           "- **Textures**: 2D textures and image files\n" +
                           "- **Models**: 3D models and meshes\n" +
                           "- **Materials**: Material assets\n" +
                           "- **Sprites**: 2D sprites and sprite sheets";

                case "Prefabs":
                    return "Reusable GameObject prefabs\n\n" +
                           "**Subfolders:**\n" +
                           "- **Characters**: Player and NPC prefabs\n" +
                           "- **Environment**: World objects and scenery\n" +
                           "- **UI**: UI element prefabs\n" +
                           "- **Effects**: Particle systems and VFX";

                case "Audio":
                    return "Sound and music assets\n\n" +
                           "**Subfolders:**\n" +
                           "- **Music**: Background music tracks\n" +
                           "- **SFX**: Sound effects\n" +
                           "- **Voices**: Voice acting and dialogue\n" +
                           "- **Mixers**: Audio mixer assets";

                case "Scenes":
                    return "Unity scene files\n\n" +
                           "**Subfolders:**\n" +
                           "- **Development**: Work-in-progress and test scenes\n" +
                           "- **Production**: Final production scenes";

                default:
                    return $"Assets for {folderName}";
            }
        }

        /// <summary>
        /// Optional folder configurations with their descriptions
        /// </summary>
        public static readonly Dictionary<string, string> OptionalFolderDescriptions = new Dictionary<string, string>()
        {
            { "Shaders", "Custom shader files and shader graphs" },
            { "Data", "Game data, databases, and configuration files" },
            { "Animations", "Animation clips, controllers, and timelines" },
            { "Editor", "Editor-only scripts and tools" },
            { "Localization", "Localization files and translation data" },
            { "Documentation", "Project documentation, design docs, and guides" },
            { "Settings", "ScriptableObject configurations and settings" },
            { "Plugins", "Native plugins and special DLLs" },
            { "StreamingAssets", "Files accessible at runtime via Application.streamingAssetsPath" },
            { "Gizmos", "Custom gizmo icons (name files to match script names)" }
        };

        /// <summary>
        /// Resources folder warning text
        /// </summary>
        public const string ResourcesWarning = @"⚠️ RESOURCES FOLDER WARNING ⚠️

The Resources folder has significant performance implications:

ISSUES:
- All assets are included in build, increasing size
- Increases application startup time
- Cannot be unloaded from memory easily
- Makes builds slower

RECOMMENDATIONS:
1. Use Addressables for dynamic content loading
2. Use AssetBundles for advanced scenarios
3. Use direct references in prefabs/ScriptableObjects when possible

VALID USE CASES:
- Small config files needed before scene loads
- Truly universal assets needed everywhere
- Quick prototyping (remove before production)

Learn more: https://docs.unity3d.com/Manual/BestPracticeUnderstandingPerformanceInUnity6.html";

        /// <summary>
        /// Third-party folder gitignore helper text template
        /// </summary>
        public const string GitignoreHelperTemplate = @"Add this line to your .gitignore to ignore the contents of this folder:

{0}/*

This is recommended for third-party assets that are:
- Large in size
- Available on the Asset Store
- Managed by package managers
- Licensed to specific team members

Keep this file tracked in Git as a reminder.";

        /// <summary>
        /// Third-party folder description
        /// </summary>
        public const string ThirdPartyDescription = "Place all third-party assets and plugins here.\n\n" +
                                                     "Consider adding this folder to .gitignore if assets are purchased or large.";

        /// <summary>
        /// Tests folder description
        /// </summary>
        public const string TestsDescription = "Unity Test Framework tests\n\nEditMode: Tests that run in edit mode\nPlayMode: Tests that run in play mode";
    }
}
