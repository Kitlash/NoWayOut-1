using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour 
{

	[SerializeField]
	float life = 100f;

	[SerializeField]
	float maxlife = 100f;

	float damage;

	[SerializeField]
	float interval;

	void Start () 
	{
		if (life <= 0) 
		{
			Destroy (gameObject, interval);
			life = maxlife;
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == " Bullet") 
		{
			damage = GetComponent<WeaponBase> ().cur_damage;
			life -= damage;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
