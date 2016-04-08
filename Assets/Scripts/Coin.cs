using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
	void OnTriggerEnter (Collider collider) 
	{
		if (collider.gameObject.name == "Player") 
		{
			GameVariables.nbcoin += 1;
			Destroy (gameObject);
		}
	}

	void OnGUI()
	{
		GUI.Label (new Rect (450, 5, 30, 30), GameVariables.nbcoin + "");
	}
}

