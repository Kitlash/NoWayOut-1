﻿using UnityEngine;
using System.Collections;

public class RotatingItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (0,Time.deltaTime * 45f ,0);
	}
}
