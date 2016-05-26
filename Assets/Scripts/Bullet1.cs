using UnityEngine;
using System.Collections;

public class Bullet1 : MonoBehaviour 
{
	float damage;

	void Start()
	{
		damage = GameObject.Find("Player").GetComponent<WeaponBase>().Damage;
	}


	void OnTriggerEnter(Collider Enemy)
	{
		if (Enemy.gameObject.CompareTag ("enemy"))
		{

			Enemy.GetComponent<EnemyLife> ().Touched = true;

			Debug.Log ("" + GetComponent<EnemyLife> () != null);

			Enemy.gameObject.SendMessage ("OnDamage", damage);

		}
	}
		
}
