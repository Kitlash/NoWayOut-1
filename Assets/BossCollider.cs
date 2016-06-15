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
		BossDeath (BossLife);
		Debug.Log (BossLife);

	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Player") 
		{
			Debug.Log ("Collision detected");

			while (amount > 0) 
			{
				amount -= Time.fixedDeltaTime;
				Debug.Log (amount);
			}
		}
	}

	void BossDeath(float life)
	{
		if (life <= 0) 
		{
			gameObject.SetActive (false);
			access.SetActive (false);
			wayout.SetActive (false);
		}
	}


	void ColliderManagment()
	{
		if (amount <= 0) 
		{
			Debug.Log ("TROLL");

			gameObject.GetComponent<Collider> ().isTrigger = false;
			gameObject.GetComponent<Collider> ().enabled = true;

			Debug.Log ("Trigger = " + gameObject.GetComponent<Collider> ().isTrigger);
			Debug.Log ("collides = " + gameObject.GetComponent<Collider> ().enabled);

			access.GetComponent<Collider> ().enabled = true;
			access.GetComponent<Collider> ().isTrigger = false;
		}
	}
}
