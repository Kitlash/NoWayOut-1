using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour 
{
	[SerializeField]
	int index;

	bool active = false;

	void Update()
	{
		if (CPactive == true) 
		{
			gameObject.SetActive (false);
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Player") 
		{
			CPactive = true;
			GameObject.Find("Player").GetComponent<SaveAndLoad>().Index = index;
			Debug.Log ("The CP is active ? " + CPactive);

		}
	}

	public bool CPactive
	{
		get { return active;}
		set { active = true;}
	}
}
