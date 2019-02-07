using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using UnityEditor;

namespace HardCodeLab.TutorialMaster.EditorUI
{
    /// <summary>
    /// Responsible for adding a section for Tutorial Master inside the Preferences menu.
    /// </summary>
    public class TutorialMasterPreferenceItem
    {
        [PreferenceItem("Tutorial Master")]
        public static void OnPreferenceGUI()
        {
            TMLogger.LoggingLevel = (LoggingLevel)EditorGUILayout.EnumPopup("Logging Level", TMLogger.LoggingLevel);
        }
    }
}