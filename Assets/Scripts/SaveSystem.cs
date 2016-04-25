using UnityEngine;
using System.Collections;

public class SaveSystem : MonoBehaviour 
{
	bool CPactive = false;

	void Start()
	{
		PlayerPrefs.SetFloat ("StartPosX", transform.position.x);
		PlayerPrefs.SetFloat ("StartPosY", transform.position.y);
		PlayerPrefs.SetFloat ("StartPosZ", transform.position.z);

		PlayerPrefs.SetFloat ("StartRotX", transform.eulerAngles.x);
		PlayerPrefs.SetFloat ("StartRotX", transform.eulerAngles.y);
		PlayerPrefs.SetFloat ("StartRotX", transform.eulerAngles.z);

	}

	void Update()
	{
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
	{
		float x = PlayerPrefs.GetFloat ("PosX");
		float y = PlayerPrefs.GetFloat ("PosY");
		float z = PlayerPrefs.GetFloat ("PosZ");

		float rx = PlayerPrefs.GetFloat ("RotX");
		float ry = PlayerPrefs.GetFloat ("RotY");
		float rz = PlayerPrefs.GetFloat ("RotZ");

		gameObject.GetComponent<PlayerHealth> ().health = PlayerPrefs.GetFloat ("Life")  * 4 / 3;

		transform.position = new Vector3 (x, y, z);
		transform.rotation = Quaternion.Euler (rx, ry, rz);
	}

	public void SetCP(bool value)
	{
		CPactive = value;
	}
}
