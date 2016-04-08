using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LevelEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        print("Here1");
        if (collider.gameObject.CompareTag("Player"))
        {
            print("Here2");
            SceneManager.LoadScene("Menu");
        }
    }
}
