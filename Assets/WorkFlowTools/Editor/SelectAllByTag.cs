using UnityEditor;
using UnityEngine;

namespace WorkFlowTools
{
    public class SelectAllByTag : ScriptableWizard
    {
        public string searchTag;
        [MenuItem("My Tools/Select By Tag")]
        public static void CreateWizard()
        {
            DisplayWizard<SelectAllByTag>("Select By Tag", "Make Selection");
        }

        public void OnWizardCreate()
        {
            GameObject[] findByTag = GameObject.FindGameObjectsWithTag(searchTag);
            Selection.objects = findByTag;
        }

        public void OnWizardUpdate()
        {

        }

        public void OnWizardOtherButton()
        {

        }
    }
}