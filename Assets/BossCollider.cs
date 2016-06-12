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

	void Update()
	{
		float BossLife = GameObject.FindGameObjectWithTag ("boss1").GetComponent<EnemyLife>().Life;
		BossDeath (BossLife);
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Player") 
		{
			amount -= Time.deltaTime;
			if (amount == 0)
			{
				gameObject.GetComponent<Collider> ().enabled = true;
				access.GetComponent<Collider> ().enabled = true;
			}
		}
	}

	void BossDeath(float life)
	{
		if (life == 0) 
		{
			gameObject.SetActive (false);
			access.SetActive (false);
			wayout.SetActive (false);
		}
	}
}
