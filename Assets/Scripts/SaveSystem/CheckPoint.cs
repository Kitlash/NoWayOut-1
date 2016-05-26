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
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Player") 
		{
			CPactive = true;
			GameObject.Find("Player").GetComponent<SaveAndLoad>().Index = index;

		}
	}

	public bool CPactive
	{
		get { return active;}
		set { active = value;}
	}
}
