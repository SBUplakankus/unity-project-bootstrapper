using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace ProjectBootstrap.Editor
{
    /// <summary>
    /// Handles the actual creation of folders and manages the generation process
    /// </summary>
    public class FolderCreator
    {
        private readonly FolderGeneratorSettings m_Settings;
        private int m_FoldersCreated;

        /// <summary>
        /// Gets the number of folders created in the last generation
        /// </summary>
        public int FoldersCreated => m_FoldersCreated;

        public FolderCreator(FolderGeneratorSettings settings)
        {
            m_Settings = settings;
        }

        /// <summary>
        /// Main method to generate the complete folder structure
        /// </summary>
        public void GenerateFolders()
        {
            m_FoldersCreated = 0;

            try
            {
                // Step 1: _ThirdParty at root level
                CreateThirdPartyFolder();

                // Step 2: Determine base path
                string basePath = DetermineBasePath();

                // Step 3: Create core folder structure
                CreateCoreFolders(basePath);

                // Step 4: Create optional folders
                CreateOptionalFolders(basePath);

                // Step 5: Create Unity special folders
                CreateUnitySpecialFolders();

                // Refresh the asset database
                AssetDatabase.Refresh();

                Debug.Log($"[Folder Generator] Successfully created {m_FoldersCreated} folders!");
            }
            catch (Exception e)
            {
                Debug.LogError($"[Folder Generator] Error during generation: {e.Message}");
                throw;
            }
        }

        /// <summary>
        /// Creates the _ThirdParty folder if enabled
        /// </summary>
        private void CreateThirdPartyFolder()
        {
            if (!m_Settings.IncludeThirdParty)
                return;

            string thirdPartyPath = CreateFolderSafe("Assets", "_ThirdParty");
            if (!string.IsNullOrEmpty(thirdPartyPath))
            {
                FileGenerator.CreateGitignoreHelper(thirdPartyPath);
                if (m_Settings.CreateReadmeFiles)
                {
                    FileGenerator.CreateReadme(thirdPartyPath, "Third-Party Assets",
                        FolderStructureData.ThirdPartyDescription);
                }
            }
        }

        /// <summary>
        /// Determines the base path for folder creation
        /// </summary>
        private string DetermineBasePath()
        {
            string basePath = "Assets";

            if (m_Settings.UseProjectRoot)
            {
                basePath = Path.Combine("Assets", m_Settings.ProjectRootName).Replace("\\", "/");
                if (!AssetDatabase.IsValidFolder(basePath))
                {
                    AssetDatabase.CreateFolder("Assets", m_Settings.ProjectRootName);
                    m_FoldersCreated++;
                }
            }

            return basePath;
        }

        /// <summary>
        /// Creates all core folders and their subfolders
        /// </summary>
        private void CreateCoreFolders(string basePath)
        {
            foreach (var kvp in FolderStructureData.CoreFolders)
            {
                string parentPath = CreateFolderSafe(basePath, kvp.Key);
                if (!string.IsNullOrEmpty(parentPath))
                {
                    // Create subfolders
                    foreach (var sub in kvp.Value)
                    {
                        CreateFolderSafe(parentPath, sub);
                    }

                    // Add README to parent folder
                    if (m_Settings.CreateReadmeFiles)
                    {
                        FileGenerator.CreateReadme(parentPath, kvp.Key,
                            FolderStructureData.GetFolderDescription(kvp.Key));
                    }
                }
            }
        }

        /// <summary>
        /// Creates optional folders based on settings
        /// </summary>
        private void CreateOptionalFolders(string basePath)
        {
            if (m_Settings.IncludeShaders)
                CreateOptionalFolder(basePath, "Shaders");

            if (m_Settings.IncludeData)
                CreateOptionalFolder(basePath, "Data");

            if (m_Settings.IncludeAnimations)
                CreateOptionalFolder(basePath, "Animations");

            if (m_Settings.IncludeEditorFolder)
                CreateOptionalFolder(basePath, "Editor");

            if (m_Settings.IncludeLocalization)
                CreateOptionalFolder(basePath, "Localization");

            if (m_Settings.IncludeDocumentation)
                CreateOptionalFolder(basePath, "Documentation");

            if (m_Settings.IncludeSettings)
                CreateOptionalFolder(basePath, "Settings");

            if (m_Settings.IncludeTests)
                CreateTestsFolders(basePath);

            if (m_Settings.IncludePlugins)
                CreateOptionalFolder(basePath, "Plugins");
        }

        /// <summary>
        /// Creates the Tests folder with EditMode and PlayMode subfolders
        /// </summary>
        private void CreateTestsFolders(string basePath)
        {
            string testsPath = CreateFolderSafe(basePath, "Tests");
            if (!string.IsNullOrEmpty(testsPath))
            {
                CreateFolderSafe(testsPath, "EditMode");
                CreateFolderSafe(testsPath, "PlayMode");
                if (m_Settings.CreateReadmeFiles)
                {
                    FileGenerator.CreateReadme(testsPath, "Tests", FolderStructureData.TestsDescription);
                }
            }
        }

        /// <summary>
        /// Creates Unity special folders (Resources, StreamingAssets, Gizmos)
        /// </summary>
        private void CreateUnitySpecialFolders()
        {
            if (m_Settings.IncludeResources)
            {
                string resourcesPath = CreateFolderSafe("Assets", "Resources");
                if (!string.IsNullOrEmpty(resourcesPath))
                {
                    FileGenerator.CreateResourcesWarning(resourcesPath);
                }
            }

            if (m_Settings.IncludeStreamingAssets)
                CreateOptionalFolder("Assets", "StreamingAssets");

            if (m_Settings.IncludeGizmos)
                CreateOptionalFolder("Assets", "Gizmos");
        }

        /// <summary>
        /// Creates an optional folder with README if enabled
        /// </summary>
        private void CreateOptionalFolder(string basePath, string folderName)
        {
            string folderPath = CreateFolderSafe(basePath, folderName);
            if (!string.IsNullOrEmpty(folderPath) && m_Settings.CreateReadmeFiles)
            {
                if (FolderStructureData.OptionalFolderDescriptions.TryGetValue(folderName, out string description))
                {
                    FileGenerator.CreateReadme(folderPath, folderName, description);
                }
            }
        }

        /// <summary>
        /// Safely creates a folder, checking if it already exists first
        /// </summary>
        /// <param name="parent">Parent folder path</param>
        /// <param name="folderName">Name of the folder to create</param>
        /// <returns>Full path of the folder if created or already exists, empty string on failure</returns>
        private string CreateFolderSafe(string parent, string folderName)
        {
            string fullPath = Path.Combine(parent, folderName).Replace("\\", "/");

            if (AssetDatabase.IsValidFolder(fullPath))
            {
                Debug.LogWarning($"[Folder Generator] Folder already exists, skipping: {fullPath}");
                return fullPath;
            }

            try
            {
                string guid = AssetDatabase.CreateFolder(parent, folderName);
                if (!string.IsNullOrEmpty(guid))
                {
                    m_FoldersCreated++;

                    // Create .gitkeep if enabled
                    if (m_Settings.CreateGitKeepFiles)
                    {
                        FileGenerator.CreateGitKeepFile(fullPath);
                    }

                    return fullPath;
                }
            }
            catch (Exception e)
            {
                Debug.LogWarning($"[Folder Generator] Failed to create folder: {fullPath}\n{e.Message}");
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets a formatted success message
        /// </summary>
        public string GetSuccessMessage()
        {
            string message = $"Successfully generated folder structure!\n\n" +
                             $"📁 Folders created: {m_FoldersCreated}\n" +
                             $"📍 Base path: {(m_Settings.UseProjectRoot ? "Assets/" + m_Settings.ProjectRootName : "Assets")}\n\n";

            if (m_Settings.CreateGitKeepFiles)
                message += "✓ Created .gitkeep files\n";
            if (m_Settings.CreateReadmeFiles)
                message += "✓ Created README files\n";
            if (m_Settings.IncludeResources)
                message += "⚠️ Resources folder warning file created\n";

            return message;
        }
    }
}
