using UnityEditor;
using UnityEngine;

namespace ProjectBootstrap.Editor
{
    /// <summary>
    /// Unity Folder Structure Generator
    /// Creates a comprehensive, industry-standard folder hierarchy for Unity projects
    /// </summary>
    public class ProjectBootstrap : EditorWindow
    {
        private FolderPreset m_SelectedPreset = FolderPreset.Standard;
        private FolderPreset m_LastPreset = FolderPreset.Standard;
        private FolderGeneratorSettings m_Settings = new FolderGeneratorSettings();
        private Vector2 m_ScrollPosition;

        #region Menu Item

        /// <summary>
        /// Opens the Project Bootstrap editor window
        /// </summary>
        [MenuItem("Tools/Project Bootstrap")]
        public static void ShowWindow()
        {
            var window = GetWindow<ProjectBootstrap>("Folder Generator");
            window.minSize = new Vector2(400, 500);
        }

        #endregion

        #region GUI

        /// <summary>
        /// Renders the editor window GUI
        /// </summary>
        private void OnGUI()
        {
            m_ScrollPosition = EditorGUILayout.BeginScrollView(m_ScrollPosition);

            DrawHeader();
            DrawPresetSection();
            
            GUILayout.Space(10);

            EditorGUILayout.BeginVertical("box");
            DrawRootSettings();
            GUILayout.Space(5);
            DrawOptionalFolders();
            GUILayout.Space(5);
            DrawUnitySpecialFolders();
            GUILayout.Space(5);
            DrawAdvancedOptions();
            EditorGUILayout.EndVertical();

            GUILayout.Space(10);
            DrawGenerateButton();

            EditorGUILayout.EndScrollView();
        }

        private void DrawHeader()
        {
            GUILayout.Space(10);
            GUILayout.Label("Project Bootstrap", EditorStyles.boldLabel);
            EditorGUILayout.HelpBox("Generate a professional folder structure for your Unity project.", MessageType.Info);
            GUILayout.Space(10);
        }

        private void DrawPresetSection()
        {
            EditorGUILayout.BeginVertical("box");
            GUILayout.Label("Presets", EditorStyles.boldLabel);

            m_SelectedPreset = (FolderPreset)EditorGUILayout.EnumPopup("Folder Preset", m_SelectedPreset);

            if (m_SelectedPreset != m_LastPreset)
            {
                if (m_SelectedPreset != FolderPreset.Custom)
                {
                    m_Settings.ApplyPreset(m_SelectedPreset);
                }
                m_LastPreset = m_SelectedPreset;
            }

            string description = FolderGeneratorSettings.GetPresetDescription(m_SelectedPreset);
            EditorGUILayout.HelpBox(description, MessageType.None);

            EditorGUILayout.EndVertical();
        }

        private void DrawRootSettings()
        {
            GUILayout.Label("Root Settings", EditorStyles.boldLabel);

            m_Settings.UseProjectRoot = EditorGUILayout.Toggle(
                new GUIContent("Use Project Root Folder",
                    "Wrap all main folders inside a custom root folder (e.g., _ProjectName)"),
                m_Settings.UseProjectRoot
            );

            if (m_Settings.UseProjectRoot)
            {
                EditorGUI.indentLevel++;
                m_Settings.ProjectRootName = EditorGUILayout.TextField("Root Folder Name", m_Settings.ProjectRootName);
                EditorGUI.indentLevel--;
            }

            m_Settings.IncludeThirdParty = EditorGUILayout.Toggle(
                new GUIContent("Include _ThirdParty Folder",
                    "Creates a folder for third-party assets with gitignore helper"),
                m_Settings.IncludeThirdParty
            );
        }

        private void DrawOptionalFolders()
        {
            GUILayout.Label("Optional Folders", EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal();
            
            EditorGUILayout.BeginVertical();
            m_Settings.IncludeShaders = EditorGUILayout.Toggle("Shaders", m_Settings.IncludeShaders);
            m_Settings.IncludeAnimations = EditorGUILayout.Toggle("Animations", m_Settings.IncludeAnimations);
            m_Settings.IncludeData = EditorGUILayout.Toggle("Data", m_Settings.IncludeData);
            m_Settings.IncludeSettings = EditorGUILayout.Toggle("Settings", m_Settings.IncludeSettings);
            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical();
            m_Settings.IncludeEditorFolder = EditorGUILayout.Toggle("Editor", m_Settings.IncludeEditorFolder);
            m_Settings.IncludeLocalization = EditorGUILayout.Toggle("Localization", m_Settings.IncludeLocalization);
            m_Settings.IncludeDocumentation = EditorGUILayout.Toggle("Documentation", m_Settings.IncludeDocumentation);
            m_Settings.IncludeTests = EditorGUILayout.Toggle("Tests", m_Settings.IncludeTests);
            EditorGUILayout.EndVertical();
            
            EditorGUILayout.EndHorizontal();

            m_Settings.IncludePlugins = EditorGUILayout.Toggle(
                new GUIContent("Plugins", "For native plugins and special DLLs"),
                m_Settings.IncludePlugins
            );
        }

        private void DrawUnitySpecialFolders()
        {
            GUILayout.Label("Unity Special Folders", EditorStyles.boldLabel);
            EditorGUILayout.HelpBox("These folders have special meaning in Unity. Use with caution.", MessageType.Warning);

            m_Settings.IncludeResources = EditorGUILayout.Toggle(
                new GUIContent("Resources", "⚠️ Consider using Addressables instead for better performance"),
                m_Settings.IncludeResources
            );

            m_Settings.IncludeStreamingAssets = EditorGUILayout.Toggle(
                new GUIContent("StreamingAssets", "For files that need to be accessed at runtime via path"),
                m_Settings.IncludeStreamingAssets
            );

            m_Settings.IncludeGizmos = EditorGUILayout.Toggle(
                new GUIContent("Gizmos", "For custom gizmo icons in the Scene view"),
                m_Settings.IncludeGizmos
            );
        }

        private void DrawAdvancedOptions()
        {
            GUILayout.Label("Advanced Options", EditorStyles.boldLabel);

            m_Settings.CreateGitKeepFiles = EditorGUILayout.Toggle(
                new GUIContent("Create .gitkeep Files", "Ensures empty folders are tracked by Git"),
                m_Settings.CreateGitKeepFiles
            );

            m_Settings.CreateReadmeFiles = EditorGUILayout.Toggle(
                new GUIContent("Create README Files", "Adds helpful README.md files with folder descriptions"),
                m_Settings.CreateReadmeFiles
            );
        }

        private void DrawGenerateButton()
        {
            GUI.backgroundColor = new Color(0.3f, 0.8f, 0.3f);
            if (GUILayout.Button("Generate Folder Structure", GUILayout.Height(40)))
            {
                if (EditorUtility.DisplayDialog(
                        "Generate Folder Structure",
                        "This will create the folder structure in your Assets directory. Continue?",
                        "Generate",
                        "Cancel"))
                {
                    GenerateFolders();
                }
            }
            GUI.backgroundColor = Color.white;
        }

        #endregion

        #region Folder Generation

        /// <summary>
        /// Initiates the folder generation process
        /// </summary>
        private void GenerateFolders()
        {
            Undo.RecordObject(this, "Generate Folder Structure");

            try
            {
                FolderCreator creator = new FolderCreator(m_Settings);
                creator.GenerateFolders();
                
                EditorUtility.DisplayDialog("Success!", creator.GetSuccessMessage(), "OK");
            }
            catch (System.Exception e)
            {
                EditorUtility.DisplayDialog("Error", 
                    $"An error occurred during folder generation:\n\n{e.Message}", "OK");
            }
        }

        #endregion
    }
}
