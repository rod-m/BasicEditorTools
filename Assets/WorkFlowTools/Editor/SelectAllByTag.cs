using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace WorkFlowTools
{
    public class SelectAllByTag : ScriptableWizard
    {
        public string searchTag;
        public string[] tagsList; // = UnityEditorInternal.InternalEditorUtility.tags;
        public void OnWizardCreate()
        {
            Object[] findByTag = GameObject.FindGameObjectsWithTag(searchTag);
            Debug.Log($"findByTag {findByTag.Length}");
            Selection.objects = findByTag;
        }

        private void OnEnable()
        {
            tagsList = UnityEditorInternal.InternalEditorUtility.tags;
        }

        private void OnDisable()
        {
            tagsList = null;
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