using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward) * 20;
	}
}
