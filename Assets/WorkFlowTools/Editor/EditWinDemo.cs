using UnityEditor;
using UnityEngine;

namespace WorkFlowTools.Editor
{
    public class EditWinDemo : EditorWindow
    {
        [MenuItem("MENUITEM/MENUITEMCOMMAND")]
        private static void ShowWindow()
        {
            var window = GetWindow<EditWinDemo>();
            window.titleContent = new GUIContent("TITLE");
            window.Show();
        }

        private void OnGUI()
        {
            
        }
    }
}