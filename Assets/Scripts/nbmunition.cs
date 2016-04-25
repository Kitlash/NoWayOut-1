using UnityEngine;
using System.Collections;

public class nbmunition : MonoBehaviour 
{

	void OnTriggerEnter (Collider collider) 
	{
		if (collider.gameObject.name == "Player") 
		{
			GameVariables.nbmunition += 10;
			Destroy (gameObject);
		}
	
	}
		
}
