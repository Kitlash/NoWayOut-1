using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour 
{
	static public bool CPactive = false;

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Player") 
		{
			CPactive = true;

			Destroy (gameObject);
		}
	}
}
