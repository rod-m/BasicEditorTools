using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class AnimateEditExample : MonoBehaviour
{
    
    // baseSize - sets the minimum scale factor
    [SerializeField]
    private float baseSize = 1f;
    
    // freqFactor - sets the rate of scale change
    [Header("Animate Frequency")]
    [SerializeField]
    private float freqFactor = 2f;
    
    // scaleFactor - sets the amount of scale as a percentage
    [Header("Amount of scale %")]
    [SerializeField]
    private float scaleFactor = 20f;
    
    // gameObjects – list of game objects to apply animation
    /*
     *  an array of game objects which will have a
     *  line drawn to in the Scene editor
     */
    
    [Header("Objects to animate")]
    [SerializeField]
    private GameObject[] gameObjects;
    
    // using a public property to get value, private set value
    // GameObjects is accessed by DrawLineEditor
    public GameObject[]  GameObjects
    {
        get
        {
            return gameObjects;
            
        }
        private set
        {
            gameObjects = value;
            
        }
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * Every frame, each member of the object list is updated
         * The scale animation factor is derived from Sine curve over time
         * Control the animation parameters for frequency, amount and base scale
             */   
        float animCurve = 0.5f * (1f - Mathf.Sin( Time.time  * freqFactor));
        float animation = baseSize + animCurve * scaleFactor * 0.01f;
        foreach (GameObject obj in GameObjects)
        {
            obj.transform.localScale = Vector3.one * animation;
            
        }


    }
}
