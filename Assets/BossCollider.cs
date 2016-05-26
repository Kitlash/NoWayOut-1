using UnityEngine;
using System.Collections;

public class BossCollider : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Player") 
		{
			return;
		}
	}
}
