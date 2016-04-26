using UnityEngine;
using System.Collections;

public class OpponentLife : MonoBehaviour 
{
	[SerializeField]
	float health = 100f;

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Bullet") 
		{
			health -= gameObject.GetComponent<WeaponBase> ().cur_damage;
		}
	}

	void Update()
	{
		if (health <= 0) 
		{
			Destroy (gameObject);
		}
	}
}
