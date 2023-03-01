using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace WorkFlowTools.Editor
{
 

    public class FollowCurve : EditorWindow
    {
        AnimationCurve curveX = AnimationCurve.Linear(0, 0, 10, 10);
        AnimationCurve curveY = AnimationCurve.Linear(0, 0, 10, 10);
        AnimationCurve curveZ = AnimationCurve.Linear(0, 0, 10, 10);

        [MenuItem("My Tools/Create Curve For Object")]
        static void Init()
        {
            FollowCurve window = (FollowCurve)EditorWindow.GetWindow(typeof(FollowCurve));
            window.Show();
        }

        void OnGUI()
        {
            curveX = EditorGUILayout.CurveField("Animation on X", curveX);
            curveY = EditorGUILayout.CurveField("Animation on Y", curveY);
            curveZ = EditorGUILayout.CurveField("Animation on Z", curveZ);

            if (GUILayout.Button("Generate Curve"))
                AddCurveToSelectedGameObject();
        }

        void  AddCurveToSelectedGameObject()
        {
            if (Selection.activeGameObject)
            {
                FollowAnimationCurve comp =
                    Selection.activeGameObject.AddComponent<FollowAnimationCurve>();

                comp.SetCurves(curveX, curveY, curveZ);
            }
            else
            {
                Debug.LogError("No Game Object selected for adding an animation curve");
            }
        }
    }
}