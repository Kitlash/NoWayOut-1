using UnityEngine;
using System.Collections;

public class OpponentLife : MonoBehaviour 
{
	[SerializeField]
	float health = 100f;

<<<<<<< HEAD
	void OnTriggerEnter(Collider collider)
=======
	float OnTriggerEnter(Collider collider)
>>>>>>> 9de4efbfa21337a1c1c4106fdc187627e752da3b
	{
		if (collider.gameObject.name == "Bullet") 
		{
			health -= gameObject.GetComponent<WeaponBase> ().damage;
		}
<<<<<<< HEAD
=======
		return health;
>>>>>>> 9de4efbfa21337a1c1c4106fdc187627e752da3b
	}

	void Update()
	{
		if (health <= 0) 
		{
			Destroy (gameObject);
		}
	}
<<<<<<< HEAD
=======

>>>>>>> 9de4efbfa21337a1c1c4106fdc187627e752da3b
}
