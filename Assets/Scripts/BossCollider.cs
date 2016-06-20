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
		if (GameVariables.nbcoin == 10) 
		{
			gameObject.GetComponent<Collider> ().isTrigger = true;
//			gameObject.GetComponent<Collider> ().enabled = false;

//			access.GetComponent<Collider> ().enabled = false;
			access.GetComponent<Collider> ().isTrigger = true;

			Debug.Log (gameObject.GetComponent<Collider> ().isTrigger);
			Debug.Log (access.GetComponent<Collider> ().isTrigger);
		}

		ColliderManagment ();
		Debug.Log (gameObject.GetComponent<Collider> ().isTrigger);
		Debug.Log (access.GetComponent<Collider> ().isTrigger);

		BossLife = GameObject.FindGameObjectWithTag ("boss1").GetComponent<EnemyLife>().Life;

		if (BossLife <= 0) 
		{
			Destroy(gameObject);
			Destroy(access);
			Destroy(wayout);
		}

	}

	void OnTriggerEnter(Collider collider)
	{
		Debug.Log (collider.gameObject.name);

		if (collider.gameObject.name == "Player") 
		{
			Debug.Log ("Collision Detected");

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
