using UnityEditor;
using UnityEngine;

namespace WorkFlowTools.Editor
{
    public class TestEditorWindow : EditorWindow
    {
        private void OnGUI()
        {
        }

        [MenuItem("MENUITEM/MENUITEMCOMMAND")]
        private static void ShowWindow()
        {
            var window = GetWindow<TestEditorWindow>();
            window.titleContent = new GUIContent("TITLE");
            window.Show();
        }
    }
}