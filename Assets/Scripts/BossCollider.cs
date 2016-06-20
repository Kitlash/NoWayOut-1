using UnityEngine;
using System.Collections;

public class BossCollider : MonoBehaviour
{
	[SerializeField]
	float amount;

	[SerializeField]
	GameObject[] accesses;

	[SerializeField]
	GameObject wayout;

    [SerializeField]
    GameObject Boss;

    [SerializeField]
    int coinlim;

    float BossLife;

	void Start()
	{
		BossLife = Boss.GetComponent<EnemyLife>().Life;
	}

	void Update()
	{
		if (GameVariables.nbcoin == coinlim) 
		{
			gameObject.GetComponent<Collider> ().isTrigger = true;
            //			gameObject.GetComponent<Collider> ().enabled = false;

            //			access.GetComponent<Collider> ().enabled = false;
            foreach (GameObject access in accesses)
            {
                access.GetComponent<Collider>().isTrigger = true;
            }
		}

		ColliderManagment ();

		BossLife = GameObject.FindGameObjectWithTag ("boss1").GetComponent<EnemyLife>().Life;

		if (BossLife <= 0) 
		{
			Destroy(gameObject);
            foreach (GameObject access in accesses)
            {
                Destroy(access);
            }
			Destroy(wayout);
            GameVariables.nbcoin = 0;
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

            foreach (GameObject access in accesses)
            {
                access.GetComponent<Collider>().enabled = true;
                access.GetComponent<Collider>().isTrigger = false;
            }
		}
	}
}
