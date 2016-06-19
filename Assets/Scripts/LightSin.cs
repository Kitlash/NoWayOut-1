using UnityEngine;
using System.Collections;

public class LightSin : MonoBehaviour 
{
	Light Cplight;

//	float i = 0.2f;
//	int factor = 1;

	void Start () 
	{
		Cplight = GetComponent<Light> ();
	}

	// Update is called once per frame
	void Update () 
	{
		Cplight = GetComponent<Light> ();
		
//		if (i > 1)
//			factor = -1;
//		if (i < -1)
//			factor = 1;
//
//		i = factor * (i + Time.deltaTime * 0.2f);
//
//		Cplight.range += i

		if (Cplight.range >= 4 && Cplight.range <= 5) 
		{
			Cplight.range += 1 * Time.deltaTime;
		}

		if (Cplight.range >= 5 && Cplight.range > 4) 
		{
			Cplight.range -= 1 * Time.deltaTime;
		}
	}
}
