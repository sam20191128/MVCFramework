using UnityEditor;
using UnityEngine;

namespace Baedrick.ColoredHeaderCreator
{
	public class ColoredHeaderObject : MonoBehaviour
	{

#if UNITY_EDITOR
		public HeaderSettings headerSettings = new HeaderSettings();

		// If values change when in Edit Mode
		// Fix for SendMessage cannot be called during Awake, CheckConsistency, or OnValidate
		void OnValidate()
		{
			EditorApplication.delayCall += _OnValidate;
		}
		void _OnValidate()
		{
			if (!this) return;

			EditorApplication.RepaintHierarchyWindow();
			
			gameObject.tag = headerSettings.editorOnly ? "EditorOnly" : "Untagged";
		}
#endif // UNITY_EDITOR

	} // class ColoredHeaderObject

} // namespace