using UnityEngine;
using UnityEngine.SceneManagement;

namespace DevSceneMenu
{
    public class GUISceneLoaderMenu : MonoBehaviour
    {
#if UNITY_EDITOR
        // stuff here is ignored in final build!
        // this will tell others what this component does
        [TextArea] [Tooltip("This is for development only")]
        public string Notes = "This menu wont appear on final build!";
        
        void OnGUI()
        {
            // here any menu elements can be created like the Canvas
            // Make a background box
            GUI.Box(new Rect(10,10,100,90), "Loader Menu");
            
            //This adds a button for all the scenes currently add to Build Settings
            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                if(GUI.Button(new Rect(20,40 + (i *25),80,20), $"Scene {i}"))
                {
                    // Make the first button. Press this button to choose another scene
                    SceneManager.LoadScene(i);
                }
            }

        }
#endif
    }

   
}