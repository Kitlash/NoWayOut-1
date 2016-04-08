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

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*while (!InMyPoses) 
		{
			gameObject.SetActive (false);
		}*/

		//IsActivated = Active;
		//InMyPoses = GetPoses();
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