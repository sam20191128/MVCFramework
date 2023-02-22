// Created by Dedrick "Baedrick" Koh
// Version 2.1.r3
//
// This script is to keep all GUI elements together for readability

using UnityEditor;
using UnityEngine;

namespace Baedrick.ColoredHeaderCreator
{
	public partial class ColoredHeaderCreator : EditorWindow
	{

        //
        // Stores all strings for Editor Window
        //
        public static class Strings
	    {
            public const string             fileName                    = "ColoredHeaderCreatorSettings";

            public static string            windowTitle                 = "Colored Header Creator";
            public static string            logoText                    = "Baedrick | ColoredHeaders";

            public static string[]          tabHeader                   = { "Header Creator", "Header Presets" };

            public static string            propertyUndoText            = "Input Properties changed.";

            public static string            headerTitleText             = "Header Name";
            public static string            headerTitleTooltip          = "Display text for the Header.";
            public static string            headerColorTitleText        = "Header Color";
            public static string            headerColorTitleTooltip     = "Header background color.";
            public static string            headerEditorTitleText       = "Editor Only";
            public static string            headerEditorTitleTooltip    = "Enable Editor Only tag on the Header.";
            public static string            textAlignmentTitleText      = "Text Alignment";
            public static string            textAlignmentTitleToolTip   = "Header text alignment.";
            public static string            fontStyleTitleText          = "Font Style";
            public static string            fontStyleTitleToolTip       = "Header text style.";
            public static string            fontSizeTitleText           = "Font Size";
            public static string            fontSizeTitleTooltip        = "Display text for the Header.";
            public static string            fontColorTitleText          = "Font Color";
            public static string            fontColorTitleTooltip       = "Header text color.";
            public static string            dropShadowTitleText         = "Drop Shadow (Slow)";
            public static string            dropShadowTitleTooltip      = "Header text drop shadow. Warning it is slow.";

            public static string            createButtonText            = "Create Header";
            public static string            resetButtonText             = "Reset To Default";
            public static string            deleteButtonText            = "Delete All Headers";
            public static string            loadHeadersButtonText       = "Load Headers From File";
            public static string            saveHeaderPresetText        = "Save Scene Headers As Preset";

            public static string            headerSettingsFoldoutText   = "Header Settings";
            public static string            fontSettingsFoldoutText     = "Font Settings";
            public static string            loadPresetsFoldoutText      = "Load Header Preset";
            public static string            createPresetFoldoutText     = "Create Header Preset";

            public static string            headerPresetInputLoadText   = "Header Preset File";
            public static string            headerPresetInputSaveText   = "File Name";
            public static string            headerPresetFileNameText    = "New Header Preset";

            public static string            errorText                   = "This Message Shouldn't Be Shown";
            public static string            noPresetSelectedText        = "Please Select A File To Load From";
            public static string            successText                 = "Success";

            public static string            headerGameObjectName        = "%$ Header";
        }

        //
        // Stores all styles for Editor Window
        //
        public static class Styles
        {
            public static GUIStyle          logoFont;
            public static GUILayoutOption   logoPosition;
            public static GUILayoutOption   tabsLayout;

            public static GUILayoutOption   createButtonLayout;
            public static GUILayoutOption   loadHeadersButtonLayout;

            public static GUIStyle          headerFontStyle;

            public static Color             foldoutTintColor;

            static Styles()
            {
                logoFont = new GUIStyle(EditorStyles.label);
                logoFont.alignment = TextAnchor.MiddleCenter;
                logoFont.fontSize = 20;

                logoPosition = GUILayout.Height(50f);

                tabsLayout = GUILayout.Height(26f);

                createButtonLayout = GUILayout.MinHeight(50f);
                loadHeadersButtonLayout = GUILayout.MinHeight(30f);

                foldoutTintColor = EditorGUIUtility.isProSkin
                    ? new Color(1f, 1f, 1f, 0.05f)
                    : new Color(0f, 0f, 0f, 0.05f);
            }
        }

        //
        // Stores window properties for Editor Window
        //
        public static class WindowProperties
        {
            public static Vector2             windowMinSize               = new Vector2(325, 390);
        }

    } // class ColoredHeaderCreator

} // namespace