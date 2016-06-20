//BEHAN REMOSHAN
//17-06-2016
using UnityEngine;
using System.Collections;

public class MP_Billboard : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        transform.LookAt(Camera.current.transform);
    }
}
