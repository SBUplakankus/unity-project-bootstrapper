namespace ProjectBootstrap.Editor
{
    /// <summary>
    /// Configuration settings for folder structure generation
    /// </summary>
    public class FolderGeneratorSettings
    {
        // Root options
        public bool UseProjectRoot { get; set; } = true;
        public string ProjectRootName { get; set; } = "_ProjectName";
        public bool IncludeThirdParty { get; set; } = true;

        // Core optional folders
        public bool IncludeShaders { get; set; } = true;
        public bool IncludeData { get; set; } = true;
        public bool IncludeAnimations { get; set; } = true;
        public bool IncludeEditorFolder { get; set; } = true;
        public bool IncludeLocalization { get; set; } = true;
        public bool IncludeDocumentation { get; set; } = true;
        public bool IncludeSettings { get; set; } = true;
        public bool IncludeTests { get; set; } = false;
        public bool IncludePlugins { get; set; } = false;

        // Unity special folders
        public bool IncludeResources { get; set; } = false;
        public bool IncludeStreamingAssets { get; set; } = false;
        public bool IncludeGizmos { get; set; } = false;

        // Advanced options
        public bool CreateGitKeepFiles { get; set; } = true;
        public bool CreateReadmeFiles { get; set; } = true;

        /// <summary>
        /// Applies a preset configuration to these settings
        /// </summary>
        /// <param name="preset">The preset to apply</param>
        public void ApplyPreset(FolderPreset preset)
        {
            switch (preset)
            {
                case FolderPreset.Minimal:
                    SetMinimalPreset();
                    break;
                case FolderPreset.Standard:
                    SetStandardPreset();
                    break;
                case FolderPreset.Complete:
                    SetCompletePreset();
                    break;
                case FolderPreset.GameJam:
                    SetGameJamPreset();
                    break;
            }
        }

        private void SetMinimalPreset()
        {
            UseProjectRoot = false;
            IncludeThirdParty = false;
            IncludeShaders = false;
            IncludeData = false;
            IncludeAnimations = false;
            IncludeEditorFolder = false;
            IncludeLocalization = false;
            IncludeDocumentation = false;
            IncludeSettings = false;
            IncludeTests = false;
            IncludePlugins = false;
            IncludeResources = false;
            IncludeStreamingAssets = false;
            IncludeGizmos = false;
            CreateGitKeepFiles = true;
            CreateReadmeFiles = false;
        }

        private void SetStandardPreset()
        {
            UseProjectRoot = true;
            IncludeThirdParty = true;
            IncludeShaders = true;
            IncludeData = true;
            IncludeAnimations = true;
            IncludeEditorFolder = true;
            IncludeLocalization = false;
            IncludeDocumentation = true;
            IncludeSettings = true;
            IncludeTests = false;
            IncludePlugins = false;
            IncludeResources = false;
            IncludeStreamingAssets = false;
            IncludeGizmos = false;
            CreateGitKeepFiles = true;
            CreateReadmeFiles = true;
        }

        private void SetCompletePreset()
        {
            UseProjectRoot = true;
            IncludeThirdParty = true;
            IncludeShaders = true;
            IncludeData = true;
            IncludeAnimations = true;
            IncludeEditorFolder = true;
            IncludeLocalization = true;
            IncludeDocumentation = true;
            IncludeSettings = true;
            IncludeTests = true;
            IncludePlugins = true;
            IncludeResources = false;
            IncludeStreamingAssets = true;
            IncludeGizmos = true;
            CreateGitKeepFiles = true;
            CreateReadmeFiles = true;
        }

        private void SetGameJamPreset()
        {
            UseProjectRoot = false;
            IncludeThirdParty = true;
            IncludeShaders = false;
            IncludeData = true;
            IncludeAnimations = true;
            IncludeEditorFolder = false;
            IncludeLocalization = false;
            IncludeDocumentation = false;
            IncludeSettings = false;
            IncludeTests = false;
            IncludePlugins = false;
            IncludeResources = false;
            IncludeStreamingAssets = false;
            IncludeGizmos = false;
            CreateGitKeepFiles = false;
            CreateReadmeFiles = false;
        }

        /// <summary>
        /// Gets a description for the given preset
        /// </summary>
        public static string GetPresetDescription(FolderPreset preset)
        {
            switch (preset)
            {
                case FolderPreset.Minimal:
                    return "Basic structure: Scripts, Art, Prefabs, Audio, Scenes";
                case FolderPreset.Standard:
                    return "Recommended for most projects: Core folders + common optional folders";
                case FolderPreset.Complete:
                    return "All available folders including advanced options";
                case FolderPreset.GameJam:
                    return "Lightweight setup optimized for rapid prototyping";
                case FolderPreset.Custom:
                    return "Configure your own folder structure";
                default:
                    return "";
            }
        }
    }
}
