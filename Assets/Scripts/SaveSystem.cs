using UnityEngine;
using System.Collections;

public class SaveSystem : MonoBehaviour 
{
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
	}

	void Update()
	{
		cur_health = gameObject.GetComponent<PlayerHealth> ().health;

		if (cur_health <= 0)
		{
			Load ();
		}
	}

	void Load()
	{
		float x = PlayerPrefs.GetFloat ("PosX");
		float y = PlayerPrefs.GetFloat ("PosY");
		float z = PlayerPrefs.GetFloat ("PosZ");

		float rx = PlayerPrefs.GetFloat ("RotX");
		float ry = PlayerPrefs.GetFloat ("RotY");
		float rz = PlayerPrefs.GetFloat ("RotZ");

		cur_health = PlayerPrefs.GetFloat ("Life") + cur_health * 1/3;

		transform.position = new Vector3 (x, y, z);
		transform.rotation = Quaternion.Euler (rx, ry, rz);
	}
}
