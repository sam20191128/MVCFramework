// Created by Dedrick "Baedrick" Koh
// Version 2.1.r3
//
// Contains implementation of GUI window only.
// Logic can be found in ColoredHeaderCreator.cs

using UnityEditor;
using UnityEngine;

namespace Baedrick.ColoredHeaderCreator
{
	public partial class ColoredHeaderCreator : EditorWindow
	{

        // Which tab
        static int tabSelected = 0;

        // Foldout
        static bool headerBoxFoldout = true;
        static bool headerFontFoldout = true;
        static bool loadPresetsFoldout = true;
        static bool createPresetsFoldout = true;

        // Preset Tab
        static Object headerPreset;
        static string headerPresetFileName = Strings.headerPresetFileNameText;

        static bool Foldout(bool foldout, string content)
        {
            Rect rect = EditorGUILayout.GetControlRect(true, EditorGUIUtility.singleLineHeight, EditorStyles.foldout);

            EditorGUI.DrawRect(EditorGUI.IndentedRect(rect), Styles.foldoutTintColor);

            Rect foldoutRect = rect;
            foldoutRect.width = EditorGUIUtility.singleLineHeight;
            foldout = EditorGUI.Foldout(rect, foldout, "", true);

            // Show Foldout Triangle
            rect.x += EditorGUIUtility.singleLineHeight;
            EditorGUI.LabelField(rect, content, EditorStyles.boldLabel);

            return foldout;
        }

        void OnGUI()
		{
			DrawLogo();
            DrawTabs();
		}

		void DrawLogo()
		{

			Rect logoRect = EditorGUILayout.GetControlRect(Styles.logoPosition);
			if (Event.current.type == EventType.Repaint)
				Styles.logoFont.Draw(logoRect, Strings.logoText, false, false, false, false);

		}

        void DrawTabs()
        {

            Undo.undoRedoPerformed += Repaint;

            GUILayout.BeginHorizontal();
            GUILayout.Space(15f);

            EditorGUI.BeginChangeCheck();
            tabSelected = GUILayout.Toolbar(tabSelected, Strings.tabHeader, Styles.tabsLayout);

            // Unselect input fields if changed tabs
            if (EditorGUI.EndChangeCheck())
            {
                GUI.FocusControl(null);
            }

            GUILayout.Space(10f);

            GUILayout.EndHorizontal();

            switch (tabSelected)
            {
                case 0:
                    HeaderCreator();
                    break;

                case 1:
                    PresetCreator();
                    break;

                default:
                    HeaderCreator();
                    Debug.LogError(Strings.errorText);
                    break;
            }

        }

        void HeaderCreator()
		{

            GUILayout.Space(8);

            headerBoxFoldout = Foldout(headerBoxFoldout, Strings.headerSettingsFoldoutText);

            if (headerBoxFoldout)
            {
                EditorGUI.BeginChangeCheck();
                string headerTextUndo = settings.headerText;
                Color headerColorUndo = settings.headerColor;
                bool headerEditorUndo = settings.editorOnly;

                headerTextUndo = EditorGUILayout.TextField(new GUIContent(Strings.headerTitleText, Strings.headerTitleTooltip), headerTextUndo);
                headerColorUndo = EditorGUILayout.ColorField(new GUIContent(Strings.headerColorTitleText, Strings.headerColorTitleTooltip), headerColorUndo);
                headerEditorUndo = EditorGUILayout.Toggle(new GUIContent(Strings.headerEditorTitleText, Strings.headerEditorTitleTooltip), headerEditorUndo);

                if (EditorGUI.EndChangeCheck())
				{
                    Undo.RecordObject(settings, Strings.propertyUndoText);
                    settings.headerText = headerTextUndo;
                    settings.headerColor = headerColorUndo;
                    settings.editorOnly = headerEditorUndo;
                }
            } // bool headerBoxFoldout

            headerFontFoldout = Foldout(headerFontFoldout, Strings.fontSettingsFoldoutText);

            if (headerFontFoldout)
            {
                EditorGUI.BeginChangeCheck();
                TextAlignmentOptions textAlignmentOptionsUndo = settings.textAlignmentOptions;
                FontStyleOptions fontStyleOptionsUndo = settings.fontStyleOptions;
                float fontSizeUndo = settings.fontSize;
                Color fontColorUndo = settings.fontColor;
                bool dropShadowUndo = settings.dropShadow;

                textAlignmentOptionsUndo = (TextAlignmentOptions)EditorGUILayout.EnumPopup(new GUIContent(Strings.textAlignmentTitleText, Strings.textAlignmentTitleToolTip), textAlignmentOptionsUndo);
                fontStyleOptionsUndo = (FontStyleOptions)EditorGUILayout.EnumPopup(new GUIContent(Strings.fontStyleTitleText, Strings.fontStyleTitleToolTip), fontStyleOptionsUndo);
                fontSizeUndo = EditorGUILayout.Slider(new GUIContent(Strings.fontSizeTitleText, Strings.fontSizeTitleTooltip), fontSizeUndo, 1, 20);
                fontColorUndo = EditorGUILayout.ColorField(new GUIContent(Strings.fontColorTitleText, Strings.fontColorTitleTooltip), fontColorUndo);
                dropShadowUndo = EditorGUILayout.Toggle(new GUIContent(Strings.dropShadowTitleText, Strings.dropShadowTitleTooltip), dropShadowUndo);

                if (EditorGUI.EndChangeCheck())
				{
                    Undo.RecordObject(settings, Strings.propertyUndoText);
                    settings.textAlignmentOptions = textAlignmentOptionsUndo;
                    settings.fontStyleOptions = fontStyleOptionsUndo;
                    settings.fontSize = fontSizeUndo;
                    settings.fontColor = fontColorUndo;
                    settings.dropShadow = dropShadowUndo;
				}
            } // bool headerFontFoldout

            GUILayout.FlexibleSpace();

            // Create Header Button
            if (GUILayout.Button(Strings.createButtonText, Styles.createButtonLayout))
            {
                CreateHeader(settings);
            }

            GUILayout.Space(2);

            // Reset Options Button
            if (GUILayout.Button(Strings.resetButtonText))
            {
                Undo.RegisterCompleteObjectUndo(settings, Strings.propertyUndoText);
                settings.ResetSettings();
            }

            // Delete all Headers button
            if (GUILayout.Button(Strings.deleteButtonText))
            {
                DeleteAllHeaders();
            }

        } // HeaderCreator

        void PresetCreator()
        {

            loadPresetsFoldout = Foldout(loadPresetsFoldout, Strings.loadPresetsFoldoutText);

            if (loadPresetsFoldout)
            {
                headerPreset = EditorGUILayout.ObjectField(Strings.headerPresetInputLoadText, headerPreset, typeof(ColoredHeaderPreset), false);

                // Load Headers Preset button
                if (GUILayout.Button(Strings.loadHeadersButtonText, Styles.loadHeadersButtonLayout))
                {
                    CreateHeadersFromPreset((ColoredHeaderPreset)headerPreset);
                }
            } // bool loadPresetsFoldout

            createPresetsFoldout = Foldout(createPresetsFoldout, Strings.createPresetFoldoutText);

            if (createPresetsFoldout)
            {
                // Save Headers Preset button
                if (GUILayout.Button(Strings.saveHeaderPresetText, Styles.loadHeadersButtonLayout))
                {
                    CreatePresetFile();
                }
            } // bool createPresetsFoldout

        } // PresetCreator

    } // class ColoredHeaderCreator

} // namespace

