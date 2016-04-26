using UnityEngine;
using System.Collections;

public class WeaponCharacteristic : MonoBehaviour 
{
	[SerializeField]
	public float damage;

	[SerializeField]
	bool IsActivated;

	[SerializeField]
	bool InMyPoses;

	void Start () 
	{
		gameObject.SetActive (IsActivated);
	}

	// Update is called once per frame
	void Update () 
	{
		if (gameObject.tag == "Weapon to pick up" && InMyPoses == true) 
		{
			Destroy (gameObject);
		}
	}

	public bool GetPoses()
	{
		Debug.Log ("In my poses" + InMyPoses);
		return InMyPoses;
	}

	public void SetPoses(bool value)
	{
			InMyPoses = value;
	}
}