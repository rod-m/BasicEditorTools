using UnityEditor;
using UnityEngine;

namespace WorkFlowTools.Editor
{
    public class TestWiz : ScriptableWizard
    {
        public string name;
        public Texture2D portrait;
        [MenuItem("Window/TestXX")]
        public static void CreateWizard()
        {
            DisplayWizard<TestWiz>("TITLE", "CREATE", "OTHER");
        }

        public void OnWizardCreate()
        {
            
        }

        public void OnWizardUpdate()
        {

        }

        public void OnWizardOtherButton()
        {

        }
    }
}