using UnityEditor;
using UnityEngine;

namespace WorkFlowTools.Editor
{
    public class TestWiz : ScriptableWizard
    {
        //public string name;
        public Texture2D portrait;

        public void OnWizardCreate()
        {
        }

        public void OnWizardOtherButton()
        {
        }

        public void OnWizardUpdate()
        {
        }

        [MenuItem("Window/TestXX")]
        public static void CreateWizard()
        {
            DisplayWizard<TestWiz>("TITLE", "CREATE", "OTHER");
        }
    }
}