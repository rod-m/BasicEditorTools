using UnityEditor;
using UnityEngine;

namespace WorkFlowTools.Editor
{
    public class TestEditorWindow : EditorWindow
    {
        [MenuItem("MENUITEM/MENUITEMCOMMAND")]
        private static void ShowWindow()
        {
            var window = GetWindow<TestEditorWindow>();
            window.titleContent = new GUIContent("TITLE");
            window.Show();
        }

        private void OnGUI()
        {
            
        }
    }
}