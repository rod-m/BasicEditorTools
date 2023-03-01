using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace WorkFlowTools.Editor
{
    public class QuantizerCreator : EditorWindow
    {
        static public GameObject beatSource;
        static public List<GameObject> beatPrefabs = new List<GameObject>();

        private int numBeats = 4;
        private int barNumber = 0;
        private int beatVSpace = 2;
        [MenuItem("My Tools/Make Beat")]
        private static void ShowWindow()
        {
            MakePrefabs();
            var window = GetWindow<QuantizerCreator>();
            window.titleContent = new GUIContent("Make Beats");
            window.Show();
        }

        static void MakePrefabs()
        {
            var beatSources = AssetDatabase.FindAssets("l:Beat");
            beatPrefabs = new List<GameObject>();
            foreach (var guid in beatSources)
            {
                var b = AssetDatabase.GUIDToAssetPath(guid);
                Debug.Log($"prefab {b}");
                var p = AssetDatabase.LoadAssetAtPath<GameObject>(b);
                beatPrefabs.Add(p);
            }
        }

        private void OnGUI()
        {
            GUILayout.Label("Use this tool to make quantized prefabs");
            EditorGUILayout.BeginHorizontal();
            //TagField
            beatSource = EditorGUILayout.ObjectField(beatSource, typeof(GameObject), false) as GameObject;
            GUILayout.Label("Vertical Space", GUILayout.Width(90));
            beatVSpace = (int)EditorGUILayout.Slider(beatVSpace, 1, 6);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            foreach (var beatPrefab in beatPrefabs)
            {
                // var z = EditorGUILayout.ObjectField(beatPrefab, typeof(GameObject), false) as GameObject;
                if (GUILayout.Button($"{beatPrefab.name}")) ChoosePrefab(beatPrefab);
            }

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
                    if (GUILayout.Button($"B{i}-{j}")) MakeBeat(i, j);
                }

                GUILayout.EndHorizontal();
            }

            GUILayout.EndVertical();
        }

        void ChoosePrefab(GameObject prefab)
        {
            beatSource = prefab;
        }

        void MakeBeat(int i, int j)
        {
            //Debug.Log($"make a beat {barNumber} {i} {j}");
            GameObject parent = null;
            GameObject[] go = Selection.gameObjects;
            if (go.Length > 0)
            {
                parent = go[0];
            }

            if (beatSource == null)
            {
                EditorUtility.DisplayDialog("Select beat", "Click a beat option!", "Ok");
                return;
            }

            string beatName = $"Beat-{barNumber}-{i}-{j}";
            GameObject instance = GameObject.Find(beatName);
            if (instance != null)
            {
                DestroyImmediate(instance);
                return;
            }
            
            instance = Instantiate(beatSource) as GameObject;
            if (parent != null)
            {
                instance.transform.parent = parent.transform;
            }

            instance.name = beatName;
            instance.transform.localPosition = new Vector3((j * (1 + barNumber) * numBeats), -i * beatVSpace, 0);
        }
    }
}