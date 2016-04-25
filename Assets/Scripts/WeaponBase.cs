using UnityEngine;
using System.Collections;

public class WeaponBase : MonoBehaviour 
{
	#region : Weapons attributs
	public float damage;

	[SerializeField]
	public GameObject Bullet_Emitter;

	[SerializeField]
	public GameObject Bullet;

	[SerializeField]
	public float Bullet_Forward_Force;

	[SerializeField]
	GameObject[] weapons = new GameObject[4];


	#endregion

	// Use this for initialization
	void Start () 
	{
		GameVariables.nbmunition = 5;

		GameVariables.cur_weapon = 0;

		Bullet_Emitter = weapons [GameVariables.cur_weapon];

		Debug.Log (Bullet_Emitter.name + "");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0) && GameVariables.nbmunition > 0) 
		{
			Shoot ();
		}

		if (Input.GetKey (KeyCode.Q)) 
		{
			Switch ();
		}

	}

	#region : methods

	void Shoot ()
	{
		//Reduction of your number of munitions currently available
		GameVariables.nbmunition--;

		//Bullet instantiation
		GameObject Temporary_Bullet_Handler;
		Temporary_Bullet_Handler = Instantiate (Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

		//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set originaly.
		//It's corrected here,
		Temporary_Bullet_Handler.transform.Rotate (Vector3.left * 90);

		//Retrieve the Rigidbody component from the instantiated Bullet and control it.
		Rigidbody Temporary_RigidBody;
		Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody> ();

		//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force. 
		Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

		//Basic Clean Up, set the Bullets to self destruct
		Destroy (Temporary_Bullet_Handler, 3.0f);

	}

	void Switch()
	{
		int len = weapons.Length;

		int i = (GameVariables.cur_weapon + 1) % len ;
	
		Debug.Log ("Current position in my array : " + GameVariables.cur_weapon);

		while(i <= len - 1  && weapons [i].GetComponent<WeaponCharacteristic> ().GetPoses () == false)
		{
			Debug.Log ("range of i before increment : " + i);
			i++;

			if (i == len - 1 ) 
			{
				i = 0;
			}
		}

		Debug.Log ("range of after while i : " + i);

		if (i != GameVariables.cur_weapon) 
		{
			weapons [GameVariables.cur_weapon].SetActive (false);
			weapons [i].SetActive (true);
			GameVariables.cur_weapon = i;
			Debug.Log ("Current position in my array after Switch : " + GameVariables.cur_weapon);
			Bullet_Emitter = weapons [GameVariables.cur_weapon];
		} 
	}

	void OnTriggerEnter( Collider collider)
	{
		WeaponCharacteristic WC = collider.gameObject.GetComponent<WeaponCharacteristic> ();

		if ( WC.gameObject.tag == "Weapon to pick up" && Input.GetKey(KeyCode.E)) 
		{
			WC.SetPoses(true); //Once InMyPoses set to true the oject on the scene is destroyed
			weapons [GameVariables.cur_weapon % weapons.Length].SetActive (false); //The current gun you're using is disabble
			foreach (GameObject w in weapons) 
			{
				if (w.name == WC.name) 
				{
					w.SetActive (true);
					w.GetComponent<WeaponCharacteristic> ().SetPoses (true);
				}
			}
		}
	}

	#endregion
}
