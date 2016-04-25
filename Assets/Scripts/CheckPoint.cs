using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour 
{
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Player") 
		{
			Debug.Log ("collision detected");

			PlayerPrefs.SetFloat ("PosX", transform.position.x);
			PlayerPrefs.SetFloat ("PosY", transform.position.y);
			PlayerPrefs.SetFloat ("PosZ", transform.position.z);

			PlayerPrefs.SetFloat ("RotX", transform.eulerAngles.x);
			PlayerPrefs.SetFloat ("RotX", transform.eulerAngles.y);
			PlayerPrefs.SetFloat ("RotX", transform.eulerAngles.z);

			//PlayerPrefs.SetFloat ("Life", gameObject.GetComponent<PlayerHealth> ().health);

			collider.gameObject.GetComponent<SaveSystem> ().SetCP (true);

			Destroy (gameObject);
		}
	}
}
