using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class CreateCustomCharacter : ScriptableWizard
    {
        public string nickname;
        public Texture2D portrait;
        public Color colour = Color.black;
        [MenuItem("My Tools/Create Character")]
        public static void CreateWizard()
        {
            DisplayWizard<CreateCustomCharacter>("Create character", "Add New", "Modify");
        }

        public void OnWizardCreate()
        {
            GameObject np = new GameObject();
            np.name = "Character";
            Character character = np.AddComponent<Character>();
            character.nickname = nickname;
            character.portrait = portrait;
        }

        public void OnWizardUpdate()
        {

        }

        public void OnWizardOtherButton()
        {

        }
    }
}