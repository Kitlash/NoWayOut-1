using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public class WeaponCharacteristic : MonoBehaviour
{
	#region : attributs
	[SerializeField]
	public float damage;

	[SerializeField]
	public bool IsActivated;

	[SerializeField]
	public bool InMyPoses;

	#endregion

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

	#region : methods
	public bool GetPoses()
	{
		return InMyPoses;
	}

	public void SetPoses(bool value)
	{
			InMyPoses = value;
	}

	public bool GetActive()
	{
		return IsActivated;
	}
		
	#endregion
}