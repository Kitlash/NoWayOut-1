using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour {

	[SerializeField]
	float health = 100f;

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Bullet")
		{
			health -= gameObject.GetComponent<WeaponBase> ().damage;
		}
	}

	void Update ()
	{
		if (health <= 0)
		{
			Destroy (gameObject);
		}
	}
}
