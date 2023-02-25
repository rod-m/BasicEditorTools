using UnityEditor;
using UnityEngine;

namespace WorkFlowTools.Editor
{
    public class StepsCreator : EditorWindow
    {
        public int numSteps = 5;
        public int numSpirals = 5;
        public float spiralRadius;
        public float stepWidth = 2f;
        public float stepHeight = 0.5f;
        public float stepDepth = 0.5f;
        private Material mat;

        private GameObject[] selected;

        private void OnGUI()
        {
            GUILayout.Label("Use this tool to make steps");

            mat = (Material)EditorGUILayout.ObjectField(mat, typeof(Material), true);
            GUILayout.BeginHorizontal();
            GUILayout.Label("Number of Steps", GUILayout.Width(115));
            numSteps = (int)EditorGUILayout.Slider(numSteps, 2, 115);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Number Of Spirals", GUILayout.Width(115));
            numSpirals = (int)EditorGUILayout.Slider(numSpirals, 0, 10);
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
            if (GUILayout.Button("Create Steps")) MakeSteps();
            // make a staircase from A to B points
            if (GUILayout.Button("Create Steps With Selected")) MakeStepsWithSelected();
        }

        [MenuItem("My Tools/Create Steps")]
        private static void ShowWindow()
        {
            var window = GetWindow<StepsCreator>();
            window.titleContent = new GUIContent("Create Steps");
            window.Show();
        }

        private void MakeStepsWithSelected()
        {
            if (selected.Length > 1)
            {
                // use selected game objects to make steps
                // to make steps between points simply lerp between the points and add new steps at each position
                var from = Vector3.zero;
                var to = Vector3.zero;
                var stepHolder = new GameObject();
                stepHolder.name = $"Staircase {selected[0].name}";
                stepHolder.transform.position = Vector3.zero;
                for (var i = 0; i < selected.Length - 1; i++)
                {
                    from = selected[i].transform.position;
                    to = selected[i + 1].transform.position;
                    for (var j = 0; j < numSteps; j++)
                    {
                        var t = j / (float)numSteps;
                        var stepPos = Vector3.Lerp(from, to, t);
                        var stepObject = new GameObject();
                        var step = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        stepObject.name = $"step {j}";
                        step.name = $"step cube {j}";
                        stepObject.transform.parent = stepHolder.transform;
                        step.transform.parent = stepObject.transform;
                        stepObject.transform.position = stepPos;
                        step.transform.localPosition = Vector3.zero;
                        step.transform.localScale = new Vector3(stepWidth, stepHeight, stepWidth);
                        if (mat != null) step.GetComponent<Renderer>().material = mat; // apply mat
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
                var stepHolder = selected[0];
                var stepParent = new GameObject();
                stepParent.name = "Stairs"; // can pivot this!
                stepParent.transform.parent = stepHolder.transform;
                stepParent.transform.localPosition = Vector3.zero;
                stepParent.transform.localRotation = stepHolder.transform.rotation;

                // create new steps

                for (var i = 0; i < numSteps; i++)
                {
                    var stepObjectPos = new Vector3(
                        0,
                        i * stepHeight,
                        i * stepDepth); // + stepParent.transform.position;
                    var stepObject = new GameObject();
                    var step = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    stepObject.name = $"step {i}";
                    step.name = $"step cube {i}";
                    if (mat != null) step.GetComponent<Renderer>().material = mat;
                    stepObject.transform.parent = stepParent.transform;

                    // 878asa 

                    stepObject.transform.localPosition = stepObjectPos;

                    if (numSpirals > 0)
                    {
                        var stepSpiralArm = new GameObject();
                        stepSpiralArm.transform.parent = stepObject.transform;
                        stepSpiralArm.name = $"Spiral step {i}";
                        var stepObjectPos2 = Vector3.zero;
                        stepObjectPos2.x = spiralRadius;


                        stepSpiralArm.transform.localPosition = stepObjectPos2;
                        step.transform.parent = stepSpiralArm.transform;

                        var rotY = 360f / numSteps * numSpirals;
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
                        step.transform.localScale = new Vector3(stepWidth, stepHeight, stepWidth);
                    else
                        step.transform.localScale = new Vector3(stepWidth, stepHeight, stepDepth);
                }
            }
            else
            {
                Debug.LogWarning("Select parent object for steps and set numSteps > 0");
            }
        }
    }
}