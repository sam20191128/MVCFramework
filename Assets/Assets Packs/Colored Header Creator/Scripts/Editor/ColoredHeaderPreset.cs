using System.Collections.Generic;
using UnityEngine;

namespace Baedrick.ColoredHeaderCreator
{
	//
	// Preset template
	//
	[System.Serializable]
	[CreateAssetMenu(fileName = "New Header Preset", menuName = "Colored Header Creator/Header Preset")]
	public class ColoredHeaderPreset : ScriptableObject
	{
		public List<HeaderSettings> coloredHeaderPreset = new List<HeaderSettings>();
	}
}