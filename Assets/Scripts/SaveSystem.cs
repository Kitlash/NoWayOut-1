using UnityEngine;
using System.Collections;

public class SaveSystem : MonoBehaviour 
{
<<<<<<< HEAD
	private bool CPactive = false;

	float cur_health;

	void Start()
	{
		PlayerPrefs.SetFloat ("PosX", transform.position.x);
		PlayerPrefs.SetFloat ("PosY", transform.position.y);
		PlayerPrefs.SetFloat ("PosZ", transform.position.z);

		PlayerPrefs.SetFloat ("RotX", transform.eulerAngles.x);
		PlayerPrefs.SetFloat ("RotY", transform.eulerAngles.y);
		PlayerPrefs.SetFloat ("RotZ", transform.eulerAngles.z);

		PlayerPrefs.SetFloat ("Life", gameObject.GetComponent<PlayerHealth>().health);

		Debug.Log (CPactive + "");
=======
	bool CPactive = false;

	void Start()
	{
		PlayerPrefs.SetFloat ("StartPosX", transform.position.x);
		PlayerPrefs.SetFloat ("StartPosY", transform.position.y);
		PlayerPrefs.SetFloat ("StartPosZ", transform.position.z);

		PlayerPrefs.SetFloat ("StartRotX", transform.eulerAngles.x);
		PlayerPrefs.SetFloat ("StartRotX", transform.eulerAngles.y);
		PlayerPrefs.SetFloat ("StartRotX", transform.eulerAngles.z);

>>>>>>> 9de4efbfa21337a1c1c4106fdc187627e752da3b
	}

	void Update()
	{
<<<<<<< HEAD
		cur_health = gameObject.GetComponent<PlayerHealth> ().health;

		if (cur_health <= 0)
		{
			Load ();
		}
	}

	void Load()
=======
		if (CPactive && gameObject.GetComponent<PlayerHealth> ().health <= 0)
		{
			Load ();
		}
		else if ( !CPactive && gameObject.GetComponent<PlayerHealth>().health <= 0)
		{
			transform.position = new Vector3 (PlayerPrefs.GetFloat ("StartPosX"), PlayerPrefs.GetFloat ("StartPosY"), PlayerPrefs.GetFloat ("StartPosZ"));
			transform.rotation = Quaternion.Euler (PlayerPrefs.GetFloat ("StartRotX"), PlayerPrefs.GetFloat ("StartRotY"), PlayerPrefs.GetFloat ("StartRotZ"));
			gameObject.GetComponent<PlayerHealth> ().health = 100f;
		
		}
	}

	public void Load()
>>>>>>> 9de4efbfa21337a1c1c4106fdc187627e752da3b
	{
		float x = PlayerPrefs.GetFloat ("PosX");
		float y = PlayerPrefs.GetFloat ("PosY");
		float z = PlayerPrefs.GetFloat ("PosZ");

		float rx = PlayerPrefs.GetFloat ("RotX");
		float ry = PlayerPrefs.GetFloat ("RotY");
		float rz = PlayerPrefs.GetFloat ("RotZ");

<<<<<<< HEAD
		cur_health = PlayerPrefs.GetFloat ("Life") + cur_health * 1/3;
=======
		gameObject.GetComponent<PlayerHealth> ().health = PlayerPrefs.GetFloat ("Life")  * 4 / 3;
>>>>>>> 9de4efbfa21337a1c1c4106fdc187627e752da3b

		transform.position = new Vector3 (x, y, z);
		transform.rotation = Quaternion.Euler (rx, ry, rz);
	}
<<<<<<< HEAD
=======

	public void SetCP(bool value)
	{
		CPactive = value;
	}
>>>>>>> 9de4efbfa21337a1c1c4106fdc187627e752da3b
}
