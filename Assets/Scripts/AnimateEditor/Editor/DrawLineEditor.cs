using UnityEditor;
using UnityEngine;

namespace AnimateEditor.Editor
{
    [CustomEditor(typeof(AnimateEditExample))]
    public class DrawLineEditor : UnityEditor.Editor
    {
        private void OnSceneGUI()
        {
            AnimateEditExample t = target as AnimateEditExample;
            // prevent errors if GameObjects is null
            if (t == null || t.AnimateObjects == null)
                return;
            // grab the center of the parent
            Vector3 center = t.transform.position;
            // iterate over game objects added to the array...
            foreach (var t1 in t.AnimateObjects)
            {
                // ... and draw a line between them
                if (t1 != null)
                    Handles.DrawLine(center, t1.transform.position);
            }
        }
    }
}