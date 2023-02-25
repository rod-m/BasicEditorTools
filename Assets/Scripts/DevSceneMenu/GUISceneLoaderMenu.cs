using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DevSceneMenu
{
    public class GUISceneLoaderMenu : MonoBehaviour
    {
#if UNITY_EDITOR
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        // stuff here is ignored in final build!
        // this will tell others what this component does
        [TextArea] [Tooltip("This is for development only")]
        public string Notes = "This menu wont appear on final build!";
        
        void OnGUI()
        {
            // here any menu elements can be created like the Canvas
            // Make a background box
            int menuCount = SceneManager.sceneCountInBuildSettings;
            int headerHeight = 40;
            int buttonHeight = 20;
            int buttonHeightandGap = 25;
            GUI.Box(new Rect(10,10,100,headerHeight + buttonHeightandGap * menuCount), "Loader Menu");
            
            //This adds a button for all the scenes currently add to Build Settings
            for (int i = 0; i < menuCount; i++)
            {
                if(GUI.Button(new Rect(20,headerHeight + (i * buttonHeightandGap),80,buttonHeight), $"Scene {i}"))
                {
                    // Make the first button. Press this button to choose another scene
                    SceneManager.LoadScene(i);
                }
            }

        }
#endif
    }

   
}