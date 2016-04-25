using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour 
{
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Player") 
		{
			PlayerPrefs.SetFloat ("PosX", transform.position.x);
			PlayerPrefs.SetFloat ("PosY", transform.position.y);
			PlayerPrefs.SetFloat ("PosZ", transform.position.z);

			PlayerPrefs.SetFloat ("Rotx", transform.eulerAngles.x);
			PlayerPrefs.SetFloat ("RotY", transform.eulerAngles.y);
			PlayerPrefs.SetFloat ("RotZ", transform.eulerAngles.z);

			PlayerPrefs.SetFloat ("Life", gameObject.GetComponent<PlayerHealth>().health);
		}
	}
}
