using UnityEngine;
using System.Collections;

public class BossCollider : MonoBehaviour
{
	[SerializeField]
	float amount;

	[SerializeField]
	GameObject access;

	[SerializeField]
	GameObject wayout;

	float BossLife;

	void Start()
	{
		BossLife = GameObject.FindGameObjectWithTag ("boss1").GetComponent<EnemyLife>().Life;
	}

	void Update()
	{
		ColliderManagment ();

		BossLife = GameObject.FindGameObjectWithTag ("boss1").GetComponent<EnemyLife>().Life;

		if (BossLife <= 0) 
		{
			Destroy(gameObject);
			Destroy(access);
			Destroy(wayout);
		}
		Debug.Log (BossLife);

	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Player") 
		{
			while (amount > 0) 
			{
				amount -= Time.deltaTime;
				Debug.Log (amount);
			}
		}
	}


	void ColliderManagment()
	{
		if (amount <= 0) 
		{
			gameObject.GetComponent<Collider> ().isTrigger = false;
			gameObject.GetComponent<Collider> ().enabled = true;

			access.GetComponent<Collider> ().enabled = true;
			access.GetComponent<Collider> ().isTrigger = false;
		}
	}
}
