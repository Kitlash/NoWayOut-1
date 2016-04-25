using UnityEngine;
using System.Collections;

public class OpponentLife : MonoBehaviour 
{
	[SerializeField]
	float health = 100f;

	float OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Bullet") 
		{
			health -= gameObject.GetComponent<WeaponBase> ().damage;
		}
		return health;
	}

	void Update()
	{
		if (health <= 0) 
		{
			Destroy (gameObject);
		}
	}

}
