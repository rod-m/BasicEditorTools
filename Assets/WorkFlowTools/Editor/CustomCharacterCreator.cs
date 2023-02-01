using UnityEditor;
using UnityEngine;

/**
 * 
 */
namespace WorkFlowTools.Editor
{
    public class CustomCharacterCreator : ScriptableWizard
    {
        public string nickname;
        public Color colour = Color.black;

        public void OnWizardCreate()
        {
            var nuGO = new GameObject();
            nuGO.name = $"Character {nickname}";
            var _np = nuGO.AddComponent<NPCharacter>();
            _np.nickname = nickname;
            _np.colour = colour;
            var _npcMove = nuGO.AddComponent<NPCMoveController>();
            _np._NpcMoveController = _npcMove;
        }

        public void OnWizardOtherButton()
        {
            if (Selection.activeTransform != null)
            {
                //have a selection
                var _np = Selection.activeTransform.GetComponent<NPCharacter>();
                if (_np != null)
                {
                    _np.nickname = nickname;
                    _np.colour = colour;
                }
            }
        }

        public void OnWizardUpdate()
        {
            helpString = "Update my character";
        }
        //public NPCMoveController _NpcMoveController;

        [MenuItem("My Tools/Custom Character Creatore")]
        public static void CreateWizard()
        {
            DisplayWizard<CustomCharacterCreator>("Create", "Add", "Update");
        }
    }
}