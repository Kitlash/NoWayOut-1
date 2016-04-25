using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour 
{
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Player") 
		{
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
			Debug.Log ("collision detected");

>>>>>>> 9de4efbfa21337a1c1c4106fdc187627e752da3b
>>>>>>> 81713441cbf51c30eab590967b47120631f32300
			PlayerPrefs.SetFloat ("PosX", transform.position.x);
			PlayerPrefs.SetFloat ("PosY", transform.position.y);
			PlayerPrefs.SetFloat ("PosZ", transform.position.z);

<<<<<<< HEAD
			PlayerPrefs.SetFloat ("Rotx", transform.eulerAngles.x);
			PlayerPrefs.SetFloat ("RotY", transform.eulerAngles.y);
			PlayerPrefs.SetFloat ("RotZ", transform.eulerAngles.z);

			PlayerPrefs.SetFloat ("Life", gameObject.GetComponent<PlayerHealth>().health);
		}
	}
=======
			PlayerPrefs.SetFloat ("RotX", transform.eulerAngles.x);
<<<<<<< HEAD
			PlayerPrefs.SetFloat ("RotY", transform.eulerAngles.y);
			PlayerPrefs.SetFloat ("RotZ", transform.eulerAngles.z);

			PlayerPrefs.SetFloat ("Life", collider.gameObject.GetComponent<PlayerHealth>().health);
=======
			PlayerPrefs.SetFloat ("RotX", transform.eulerAngles.y);
			PlayerPrefs.SetFloat ("RotX", transform.eulerAngles.z);

			//PlayerPrefs.SetFloat ("Life", gameObject.GetComponent<PlayerHealth> ().health);

			collider.gameObject.GetComponent<SaveSystem> ().SetCP (true);
>>>>>>> 9de4efbfa21337a1c1c4106fdc187627e752da3b

			Destroy (gameObject);
		}
	}
<<<<<<< HEAD

=======
>>>>>>> 9de4efbfa21337a1c1c4106fdc187627e752da3b
>>>>>>> 81713441cbf51c30eab590967b47120631f32300
}
