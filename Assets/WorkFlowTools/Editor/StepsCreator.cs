using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace WorkFlowTools.Editor
{
    public class StepsCreator : EditorWindow
    {
        public int numSteps = 5;
        public int numSpirals = 5;
        public float spiralRadius = 0;
        public float stepWidth = 2f;
        public float stepHeight = 0.5f;
        public float stepDepth = 0.5f;
        private Material mat;
        
        GameObject[] selected;
        
        [MenuItem("My Tools/Create Steps")]
        private static void ShowWindow()
        {
            var window = GetWindow<StepsCreator>();
            window.titleContent = new GUIContent("Create Steps");
            window.Show();
        }

        private void OnGUI()
        {
            GUILayout.Label("Use this tool to make steps");
            
            mat = (Material) EditorGUILayout.ObjectField(mat, typeof(Material), true);
            GUILayout.BeginHorizontal();
          //  numSteps = EditorGUILayout.IntField("Number of Steps", numSteps);
            GUILayout.Label("Number of Steps", GUILayout.Width(115));
            numSteps = (int) EditorGUILayout.Slider(numSteps, 2, 115);
            GUILayout.EndHorizontal();
            //numSpirals = EditorGUILayout.IntField("Number of Spirals", numSpirals);
            GUILayout.BeginHorizontal();
            GUILayout.Label("Number Of Spirals",GUILayout.Width(115));
            numSpirals = (int) EditorGUILayout.Slider(numSpirals, 0, 10);
            GUILayout.EndHorizontal();
            spiralRadius = EditorGUILayout.FloatField("Spiral Radius", spiralRadius);
            GUILayout.BeginHorizontal();
            GUILayout.Label("Step:", GUILayout.Width(60));
            GUILayout.BeginVertical();
            stepWidth = EditorGUILayout.FloatField("Width", stepWidth);
            stepHeight = EditorGUILayout.FloatField("Height", stepHeight);
            stepDepth = EditorGUILayout.FloatField("Depth", stepDepth);
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
 
            selected = Selection.gameObjects;
            if (GUILayout.Button("Create Steps"))
            {
                MakeSteps();
            }
            // make a staircase from A to B points
            if (GUILayout.Button("Create Steps With Selected"))
            {
                MakeStepsWithSelected();
            }
        }

        private void MakeStepsWithSelected()
        {
            if (selected.Length > 1)
            {
                // use selected game objects to make steps
                // to make steps between points simply lerp between the points and add new steps at each position
                Vector3 from = Vector3.zero;
                Vector3 to = Vector3.zero;
                GameObject stepHolder = new GameObject();
                stepHolder.name = $"Staircase {selected[0].name}";
                stepHolder.transform.position = Vector3.zero;
                for (int i = 0; i < selected.Length - 1; i++)
                {
                    from = selected[i].transform.position;
                    to = selected[i+1].transform.position;
                    for (int j = 0; j < numSteps; j++)
                    {
                        float t = (float)j / (float)numSteps;
                        Vector3 stepPos = Vector3.Lerp(from, to, t);
                        GameObject stepObject = new GameObject();
                        GameObject step = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        stepObject.name = $"step {j}";
                        step.name = $"step cube {j}";
                        stepObject.transform.parent = stepHolder.transform;
                        step.transform.parent = stepObject.transform;
                        stepObject.transform.position = stepPos;
                        step.transform.localPosition = Vector3.zero;
                        step.transform.localScale = new Vector3(stepWidth, stepHeight, stepWidth);
                    }

                   
                }
            }
            else
            {
                Debug.LogWarning("select more points for steps");
            }
        }

        private void MakeSteps()
        {



            if (selected.Length == 1)
            {
                GameObject stepHolder = selected[0];
                GameObject stepParent = new GameObject();
                stepParent.name = $"Stairs"; // can pivot this!
                stepParent.transform.parent = stepHolder.transform;
                stepParent.transform.localPosition = Vector3.zero;
                stepParent.transform.localRotation = stepHolder.transform.rotation;

                // create new steps

                for (int i = 0; i < numSteps; i++)
                {
                    Vector3 stepObjectPos = new Vector3(
                        0,
                        i * stepHeight,
                        i * stepDepth); // + stepParent.transform.position;
                    GameObject stepObject = new GameObject();
                    GameObject step = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    stepObject.name = $"step {i}";
                    step.name = $"step cube {i}";
                    if (mat != null) step.GetComponent<Renderer>().material = mat;
                    stepObject.transform.parent = stepParent.transform;

                    // 878asa 

                    stepObject.transform.localPosition = stepObjectPos;

                    if (numSpirals > 0)
                    {
                        GameObject stepSpiralArm = new GameObject();
                        stepSpiralArm.transform.parent = stepObject.transform;
                        stepSpiralArm.name = $"Spiral step {i}";
                        Vector3 stepObjectPos2 = Vector3.zero;
                        stepObjectPos2.x = spiralRadius;


                        stepSpiralArm.transform.localPosition = stepObjectPos2;
                        step.transform.parent = stepSpiralArm.transform;

                        float rotY = 360f / numSteps * numSpirals;
                        stepObject.transform.rotation = Quaternion.Euler(0, rotY * i, 0);
                        step.transform.localPosition = Vector3.zero;
                    }
                    else
                    {
                        // no spiral
                        step.transform.parent = stepObject.transform;
                        step.transform.localPosition = Vector3.zero;
                    }

                    if (i == 0)
                    {
                        step.transform.localScale = new Vector3(stepWidth, stepHeight, stepWidth);
                    }
                    else
                    {
                        step.transform.localScale = new Vector3(stepWidth, stepHeight, stepDepth);
                    }
                }
            }
            else
            {
                Debug.LogWarning("Select parent object for steps and set numSteps > 0");
            }
        }
    }
}