using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
	[SerializeField]
	GameObject ParticleCoin;

	void OnTriggerEnter (Collider collider) 
	{
		if (collider.gameObject.name == "Player") 
		{
			Instantiate (ParticleCoin, transform.position, transform.rotation);
			GameVariables.nbcoin += 1;
			Destroy (gameObject);

		}
	}
}

