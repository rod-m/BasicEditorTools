using UnityEditor;
using UnityEngine;

namespace WorkFlowTools
{
    public class SelectAllByTag : ScriptableWizard
    {
        public string searchTag;

        public void OnWizardCreate()
        {
            var findByTag = GameObject.FindGameObjectsWithTag(searchTag);
            Selection.objects = findByTag;
        }

        public void OnWizardOtherButton()
        {
        }

        public void OnWizardUpdate()
        {
        }

        [MenuItem("My Tools/Select By Tag")]
        public static void CreateWizard()
        {
            DisplayWizard<SelectAllByTag>("Select By Tag", "Make Selection");
        }
    }
}