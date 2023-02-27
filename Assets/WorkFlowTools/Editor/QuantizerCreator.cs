using UnityEditor;
using UnityEngine;

namespace WorkFlowTools.Editor
{
    public class QuantizerCreator : EditorWindow
    {
        static public GameObject beatSource;
        public int numBeats = 4;
        public int barNumber = 0;
        [MenuItem("My Tools/Make Beat")]
        private static void ShowWindow()
        {
            var window = GetWindow<QuantizerCreator>();
            window.titleContent = new GUIContent("Make Beats");
            window.Show();
        }

        private void OnGUI()
        {
            GUILayout.Label("Use this tool to make quantized prefabs");
            EditorGUILayout.BeginHorizontal();
            beatSource = EditorGUILayout.ObjectField(beatSource, typeof(GameObject), false) as GameObject;
            EditorGUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Number of Beats", GUILayout.Width(115));
            numBeats = (int)EditorGUILayout.Slider(numBeats, 1, 16);
            GUILayout.Label("Bar Number", GUILayout.Width(115));
            barNumber = (int)EditorGUILayout.Slider(barNumber, 0, 4);
            GUILayout.EndHorizontal();
            
            GUILayout.BeginVertical();
            for (int i = 0; i < 4; i++)
            {
                GUILayout.BeginHorizontal();
                for (int j = 0; j < numBeats; j++)
                {
                    if (GUILayout.Button($"B{i}-{j}")) MakeBeat(i,j);
                }

                GUILayout.EndHorizontal();
            }

            GUILayout.EndVertical();
        }

        void MakeBeat(int i, int j)
        {
            Debug.Log($"make a beat {barNumber} {i} {j}");
            GameObject parent = null;
            GameObject[] go = Selection.gameObjects;
            if (go.Length > 0)
            {
                parent = go[0];
            }
            if (beatSource != null)
            {
                string beatName = $"Beat-{barNumber}-{i}-{j}";
                GameObject instance = GameObject.Find(beatName);
                if (instance == null)
                {
                    instance = Instantiate(beatSource) as GameObject;
                }
                if (parent != null)
                {
                    instance.transform.parent = parent.transform;
                }

                int beatSpace = 2;
                instance.name = beatName;
                float xScale = 4.0f / (float)numBeats;
                instance.transform.localScale = new Vector3(xScale,1 ,1);
                instance.transform.localPosition = new Vector3((j* beatSpace) + (barNumber * numBeats * beatSpace) + xScale/2, -i * beatSpace, 0);
                
            }
        }
    }
}