namespace ProjectBootstrap.Editor
{
    /// <summary>
    /// Available preset configurations for folder structure generation
    /// </summary>
    public enum FolderPreset
    {
        /// <summary>User-defined custom configuration</summary>
        Custom,
        /// <summary>Basic structure with core folders only</summary>
        Minimal,
        /// <summary>Recommended setup for most projects</summary>
        Standard,
        /// <summary>All available folders and options enabled</summary>
        Complete,
        /// <summary>Lightweight structure for rapid prototyping</summary>
        GameJam
    }
}
