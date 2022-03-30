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
        //public NPCMoveController _NpcMoveController;
        
        [MenuItem("My Tools/Custom Character Creatore")]
        public static void CreateWizard()
        {
            DisplayWizard<CustomCharacterCreator>("Create", "Add", "Update");
        }

        public void OnWizardCreate()
        {
            GameObject nuGO = new GameObject();
            nuGO.name = $"Character {nickname}";
            NPCharacter _np = nuGO.AddComponent<NPCharacter>();
            _np.nickname = nickname;
            _np.colour = colour;
            NPCMoveController _npcMove = nuGO.AddComponent<NPCMoveController>();
            _np._NpcMoveController = _npcMove;

        }

        public void OnWizardUpdate()
        {
            helpString = "Update my character";
        }

        public void OnWizardOtherButton()
        {
            if (Selection.activeTransform != null)
            {
                //have a selection
                NPCharacter _np = Selection.activeTransform.GetComponent<NPCharacter>();
                if (_np != null)
                {
                    _np.nickname = nickname;
                    _np.colour = colour;
                }
            }
        }
    }
}