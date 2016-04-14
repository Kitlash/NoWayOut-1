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
}

