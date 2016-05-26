using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour 
{
	Rect crosshairRect;
	Texture crosshairTexture;

	void Start () 
	{
		float crosshairSize = Screen.width * 0.1f;
		crosshairTexture = Resources.Load ("Weapons/Assault Rifle A3/Assault_Rifle_crosshair") as Texture;
		crosshairRect = new Rect(Screen.width / 2 - crosshairSize/2, Screen.height /2 - crosshairSize/2, crosshairSize, crosshairSize);
	}

	void OnGUI () 
	{
		if (Input.GetKey(KeyCode.F))
			GUI.DrawTexture (crosshairRect, crosshairTexture);
	
	}
}
