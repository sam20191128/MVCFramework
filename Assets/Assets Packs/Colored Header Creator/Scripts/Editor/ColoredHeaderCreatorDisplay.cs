// Created by Dedrick "Baedrick" Koh
// Version 2.1.r2
//
// Draws Headers in Hierarchy Window

using UnityEditor;
using UnityEngine;

namespace Baedrick.ColoredHeaderCreator
{

	[InitializeOnLoad]
	public static class ColoredHeaderCreatorDisplay
	{

		static ColoredHeaderCreatorDisplay()
		{
			// Performs action for every visible item in Hierarchy Window
			EditorApplication.hierarchyWindowItemOnGUI += RenderObjects;
		}

		static void RenderObjects(int instanceID, Rect selectionRect)
		{
			GameObject sceneGameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

			// Skips when Object is not valid
			if (sceneGameObject == null)
				return;

			if (sceneGameObject.name == ColoredHeaderCreator.Strings.headerGameObjectName && sceneGameObject.GetComponent(typeof(ColoredHeaderObject)) != null)
			{
				//EditorGUI.DrawRect(selectionRect, Color.cyan);
				RenderHeaders(sceneGameObject, selectionRect);
			}
		}

		// Unpacks header settings and draws header
		static void RenderHeaders(GameObject gameObject, Rect selectionRect)
		{
			HeaderSettings headerSettings = gameObject.GetComponent(typeof(ColoredHeaderObject)).GetComponent<ColoredHeaderObject>().headerSettings;

			// Header Properties
			string headerText = headerSettings.headerText;
			Color headerColor = headerSettings.headerColor;
			TextAlignmentOptions textAlignmentOptions = headerSettings.textAlignmentOptions;
			FontStyleOptions fontStyleOptions = headerSettings.fontStyleOptions;
			float fontSize = headerSettings.fontSize;
			Color fontColor = headerSettings.fontColor;
			bool dropShadow = headerSettings.dropShadow;

			ColoredHeaderCreator.Styles.headerFontStyle = new GUIStyle(EditorStyles.label);

			switch ((int)textAlignmentOptions)
			{
				case 0:
					ColoredHeaderCreator.Styles.headerFontStyle.alignment = TextAnchor.MiddleCenter;
					break;
				case 1:
					ColoredHeaderCreator.Styles.headerFontStyle.alignment = TextAnchor.MiddleLeft;
					break;
				case 2:
					ColoredHeaderCreator.Styles.headerFontStyle.alignment = TextAnchor.MiddleRight;
					break;
			}

			switch ((int)fontStyleOptions)
			{
				case 0:
					ColoredHeaderCreator.Styles.headerFontStyle.fontStyle = FontStyle.Bold;
					break;
				case 1:
					ColoredHeaderCreator.Styles.headerFontStyle.fontStyle = FontStyle.Normal;
					break;
				case 2:
					ColoredHeaderCreator.Styles.headerFontStyle.fontStyle = FontStyle.Italic;
					break;
				case 3:
					ColoredHeaderCreator.Styles.headerFontStyle.fontStyle = FontStyle.BoldAndItalic;
					break;
			}

			ColoredHeaderCreator.Styles.headerFontStyle.fontSize = Mathf.RoundToInt(fontSize);
			ColoredHeaderCreator.Styles.headerFontStyle.normal.textColor = fontColor;

			if (!dropShadow)
			{
				EditorGUI.DrawRect(selectionRect, headerColor);
				EditorGUI.LabelField(selectionRect, headerText.ToUpperInvariant(), ColoredHeaderCreator.Styles.headerFontStyle);
			}
			else
			{
				EditorGUI.DrawRect(selectionRect, headerColor);
				EditorGUI.DropShadowLabel(selectionRect, headerText.ToUpperInvariant(), ColoredHeaderCreator.Styles.headerFontStyle);
			}
		} // RenderHeaders

	} // class ColoredHeaderCreatorDisplay

} // namespace