using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour 
{
	[SerializeField]
	Vector3 AimPose = new Vector3();

	[SerializeField]
	Vector3 SteadPose = new Vector3();

	void Update () 
	{
		if (Input.GetKey(KeyCode.F))
			gameObject.transform.localPosition = AimPose;
		if (!Input.GetKey (KeyCode.F))
			gameObject.transform.localPosition = SteadPose;
	}

}
