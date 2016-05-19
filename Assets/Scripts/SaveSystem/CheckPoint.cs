using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour 
{
	[SerializeField]
	static public bool CPactive = false;

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Player") 
		{
			CPactive = true;

			Debug.Log ("The CP is active ? " + CPactive);

			Destroy (gameObject);
		}
	}
}
