// Created by Dedrick "Baedrick" Koh
// Version 2.1.r3
//
// Contains implementation of functions for GUI window.
// GUI implementation can be found in ColoredHeaderCreatorGUI.cs

using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace Baedrick.ColoredHeaderCreator
{
	public partial class ColoredHeaderCreator : EditorWindow
	{

		ColoredHeaderCreatorSettings settings;

		void OnEnable()
		{
			if (!LoadSettings())
				CreateSettingsAsset();

			settings = LoadSettings();
		}

		void OnDisable()
		{
			EditorUtility.SetDirty(settings);
		}

		// Add menu named "Colored Header Creator" to the Tools menu
		[MenuItem("Tools/Colored Header Creator %H")]
		static void CreateWindow()
		{
 			// Get existing open window or if none, make a new one
			EditorWindow window = GetWindow<ColoredHeaderCreator>(Strings.windowTitle);
			window.minSize = WindowProperties.windowMinSize;
		} // CreateWindow

		// Add header object to the object creation menu
		[MenuItem("GameObject/Colored Header", false, 10)]
		static void CreateHeaderGameObject(MenuCommand menuCommand)
		{
			// Create a custom game object
			GameObject obj = new GameObject(Strings.headerGameObjectName);

			// Ensure it gets reparented if this was a context click (otherwise does nothing)
			GameObjectUtility.SetParentAndAlign(obj, menuCommand.context as GameObject);

			// Register the creation in the undo system
			Undo.RegisterCreatedObjectUndo(obj, "Create Header");
			obj.AddComponent<ColoredHeaderObject>();

			// Set header to default values
			HeaderSettings headerSettings = obj.GetComponent(typeof(ColoredHeaderObject)).GetComponent<ColoredHeaderObject>().headerSettings;

			headerSettings.headerText = "New Header";
			headerSettings.headerColor = Color.gray;
			headerSettings.editorOnly = true;
			headerSettings.textAlignmentOptions = TextAlignmentOptions.Center;
			headerSettings.fontStyleOptions = FontStyleOptions.Bold;
			headerSettings.fontSize = 12f;
			headerSettings.fontColor = Color.white;
			headerSettings.dropShadow = false;

			// Select the header
			Selection.activeObject = obj;
		}

		ColoredHeaderCreatorSettings LoadSettings()
		{
			var result = EditorGUIUtility.Load($"Baedrick/Colored Header Creator/Scripts/Runtime/{Strings.fileName}.asset") as ColoredHeaderCreatorSettings;
			if (result != null)
				return result;

			var guids = AssetDatabase.FindAssets("t:" + nameof(ColoredHeaderCreatorSettings));
			if (guids.Length == 0)
				return null;

			return AssetDatabase.LoadAssetAtPath<ColoredHeaderCreatorSettings>(AssetDatabase.GUIDToAssetPath(guids[0])); ;
		}

		void CreateSettingsAsset()
		{
			string path = "Assets/Baedrick/Colored Header Creator/Scripts";

			// Creates setting asset
			ScriptableObject asset = CreateInstance<ColoredHeaderCreatorSettings>();
			AssetDatabase.CreateAsset(asset, path + $"/{Strings.fileName}.asset");
		}

		void CreateHeader(ColoredHeaderCreatorSettings settings)
		{
			string name = Strings.headerGameObjectName;
			GameObject obj = new GameObject(name);

			// Add header component with properties
			obj.AddComponent<ColoredHeaderObject>();
			HeaderSettings headerSettings = obj.GetComponent(typeof(ColoredHeaderObject)).GetComponent<ColoredHeaderObject>().headerSettings;

			headerSettings.headerText	= settings.headerText;
			headerSettings.headerColor = settings.headerColor;
			headerSettings.editorOnly = settings.editorOnly;
			headerSettings.textAlignmentOptions = settings.textAlignmentOptions;
			headerSettings.fontStyleOptions = settings.fontStyleOptions;
			headerSettings.fontSize = settings.fontSize;
			headerSettings.fontColor = settings.fontColor;
			headerSettings.dropShadow = settings.dropShadow;

			// Header set editor only tag
			// Unity removes all objects with Editor Only tag during Build
			if (headerSettings.editorOnly)
				obj.tag = "EditorOnly";
			else
				obj.tag = "Untagged";

			// Zero out transforms
			obj.transform.position = Vector3.zero;

			// Register undo operation
			Undo.RegisterCreatedObjectUndo(obj, "Created Header");

			// Select Header object
			Selection.activeObject = obj;
		}

		void DeleteAllHeaders()
		{
			GameObject[] sceneGameObject = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
			List<GameObject> headerObjects = new List<GameObject>();
			foreach (GameObject obj in sceneGameObject)
			{
				if (obj.name == Strings.headerGameObjectName && obj.GetComponent(typeof(ColoredHeaderObject)) != null)
				{
					headerObjects.Add(obj);
				}
			}

			foreach (GameObject obj in headerObjects)
			{
				obj.transform.DetachChildren();
				Undo.DestroyObjectImmediate(obj);
			}

			headerObjects.Clear();
		}

		void CreateHeadersFromPreset(ColoredHeaderPreset headerPreset)
		{
			if (headerPreset == null)
			{
				Debug.LogError(Strings.noPresetSelectedText);
				return;
			}
			
			foreach (HeaderSettings header in headerPreset.coloredHeaderPreset)
			{
				string name = Strings.headerGameObjectName;
				GameObject obj = new GameObject(name);

				// Add header component with properties
				obj.AddComponent<ColoredHeaderObject>();
				HeaderSettings headerSettings = obj.GetComponent(typeof(ColoredHeaderObject)).GetComponent<ColoredHeaderObject>().headerSettings;

				headerSettings.headerText = header.headerText;
				headerSettings.headerColor = header.headerColor;
				headerSettings.editorOnly = header.editorOnly;
				headerSettings.textAlignmentOptions = header.textAlignmentOptions;
				headerSettings.fontStyleOptions = header.fontStyleOptions;
				headerSettings.fontSize = header.fontSize;
				headerSettings.fontColor = header.fontColor;
				headerSettings.dropShadow = header.dropShadow;

				// Header set editor only tag
				if (headerSettings.editorOnly)
					// Unity removes all objects with Editor Only tag during Build
					obj.tag = "EditorOnly";
				else
					obj.tag = "Untagged";

				// Zero out transforms
				obj.transform.position = Vector3.zero;

				// Register undo operation
				Undo.RegisterCreatedObjectUndo(obj, "Created Header");

				// Select Header object
				Selection.activeObject = obj;
			}
		} // CreateHeadersFromPreset

		void CreatePresetFile()
		{
			string path = EditorUtility.SaveFilePanelInProject("Save Colored Header Preset File", Strings.headerPresetFileNameText, "asset", "Enter a file name");
			if (path.Length != 0)
			{
				// Creates preset file
				ScriptableObject asset = CreateInstance<ColoredHeaderPreset>();
				AssetDatabase.CreateAsset(asset, path);

				// Loads preset file
				ColoredHeaderPreset result = EditorGUIUtility.Load(path) as ColoredHeaderPreset;
				result.coloredHeaderPreset.Clear();
				
				// Get all headers in the scene
				GameObject[] sceneGameObject = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
				foreach (GameObject obj in sceneGameObject)
				{
					// Saves header settings to preset file
					if (obj.name == Strings.headerGameObjectName && obj.GetComponent(typeof(ColoredHeaderObject)) != null)
					{
						HeaderSettings presetSettings = new HeaderSettings();
						HeaderSettings header = obj.GetComponent(typeof(ColoredHeaderObject)).GetComponent<ColoredHeaderObject>().headerSettings;

						presetSettings.headerText = header.headerText;
						presetSettings.headerColor = header.headerColor;
						presetSettings.editorOnly = header.editorOnly;
						presetSettings.textAlignmentOptions = header.textAlignmentOptions;
						presetSettings.fontStyleOptions = header.fontStyleOptions;
						presetSettings.fontSize = header.fontSize;
						presetSettings.fontColor = header.fontColor;
						presetSettings.dropShadow = header.dropShadow;
						
						result.coloredHeaderPreset.Add(presetSettings);
					}

					EditorUtility.SetDirty(result);
					
				}

				AssetDatabase.SaveAssets();
				AssetDatabase.Refresh();
				Debug.Log(Strings.successText);
			}
		} // CreatePresetFile

	} // class ColoredHeaderCreator

} // namespace