using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class CreateCustomCharacter : ScriptableWizard
    {
        public string nickname;
        public Texture2D portrait;
        public Color colour = Color.black;

        public void OnWizardCreate()
        {
            var np = new GameObject();
            np.name = "Character";
            var character = np.AddComponent<Character>();
            character.nickname = nickname;
            character.portrait = portrait;
        }

        public void OnWizardOtherButton()
        {
        }

        public void OnWizardUpdate()
        {
        }

        [MenuItem("My Tools/Create Character")]
        public static void CreateWizard()
        {
            DisplayWizard<CreateCustomCharacter>("Create character", "Add New", "Modify");
        }
    }
}