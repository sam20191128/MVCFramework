#if UNITY_EDITOR

using UnityEngine;

namespace Baedrick.ColoredHeaderCreator
{

    public enum FontStyleOptions
    {
        Bold = 0,
        Normal = 1,
        Italic = 2,
        BoldAndItalic = 3
    }

    public enum TextAlignmentOptions
    {
        Center = 0,
        Left = 1,
        Right = 2
    }

    //
    // Class HeaderSettings
    //
    [System.Serializable]
    public class HeaderSettings
    {
        [Tooltip("Display text for the Header.")]
        public string headerText;
        [Tooltip("Header background color.")]
        public Color headerColor;
        [Tooltip("Enable EditorOnly tag.")]
        public bool editorOnly;

        [Space(15)]

        [Tooltip("Header text alignment.")]
        public TextAlignmentOptions textAlignmentOptions;
        [Tooltip("Header text style.")]
        public FontStyleOptions fontStyleOptions;
        [Tooltip("Header text size.")]
        public float fontSize;
        [Tooltip("Header text color.")]
        public Color fontColor;
        [Tooltip("Header text drop shadow. Warning it is slow.")]
        public bool dropShadow;
    }

    //
    // Used for editor window Undo/Redo functionality
    //
    public class ColoredHeaderCreatorSettings : ScriptableObject
	{
        // Header Settings
        public string headerText = "New Header";
        public Color headerColor = Color.gray;
        public bool editorOnly = true;

        // Text Settings
        public TextAlignmentOptions textAlignmentOptions = TextAlignmentOptions.Center;
        public FontStyleOptions fontStyleOptions = FontStyleOptions.Bold;
        public float fontSize = 12f;
        public Color fontColor = Color.white;
        public bool dropShadow = false;

        public void ResetSettings()
        {
            headerText = "New Header";
            headerColor = Color.gray;
            editorOnly = true;
            textAlignmentOptions = TextAlignmentOptions.Center;
            fontStyleOptions = FontStyleOptions.Bold;
            fontSize = 12f;
            fontColor = Color.white;
            dropShadow = false;
        }
    }

} // namespace

#endif // UNITY_EDITOR