using UnityEngine;
using System.Collections;

public class WeaponCharacteristic : MonoBehaviour 
{
	[SerializeField]
	float damage;

	[SerializeField]
	bool IsActivated = false;

	[SerializeField]
	bool InMyPoses = false;

	void Start () 
	{
		gameObject.SetActive (IsActivated);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public bool GetPoses()
	{
			return InMyPoses;
	}

	public void SetPoses(bool value)
	{
			InMyPoses = value;
	}

	bool Active
	{
		get 
		{
			return IsActivated;
		}
		set
		{
			IsActivated = value;
		}
	}
}