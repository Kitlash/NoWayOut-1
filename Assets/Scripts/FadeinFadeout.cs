using UnityEngine;
using System.Collections;
public class SceneFadeInOut : MonoBehaviour
{
    private GUITexture Tex; 
    public float fadeSpeed = 1.5f;              
    private bool sceneStarting = true;      

    void Awake()
    {
        Tex = GetComponent<GUITexture>(); // need this to use the variables of GUITexture
        Tex.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
    }

    void Update()
    {
        if (sceneStarting)
        {
            StartScene();
        }          
    }

    void FadeToClear()
    {
        Tex.color = Color.Lerp(Tex.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    void FadeToBlack()
    {
        Tex.color = Color.Lerp(Tex.color, Color.black, fadeSpeed * Time.deltaTime);
    }

    void StartScene()
    {
        FadeToClear();

        if (Tex.color.a <= 0.05f)
        {
            Tex.color = Color.clear;
            Tex.enabled = false;
            sceneStarting = false;
        }
        // Once the color of the screen is clear enough it is set to clear permanently until the end of the level is reached
    }

    public void EndScene()
    {
        Tex.enabled = true;
        FadeToBlack();

        if (Tex.color.a >= 0.95f)
        {
			//Use LoadScene
			//StartScene();
			;
        }   
        // Once the color of the screen is dark enough it goes to the next level       
    }
}