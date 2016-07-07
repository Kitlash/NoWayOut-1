using UnityEngine;
using UnityEngine.Networking;
public class PlayerSetup : NetworkBehaviour {
    [SerializeField]
    Behaviour[] componentsToEnable;

    [SerializeField]
    GameObject[] ObjectToDisable;

    [SerializeField]
    GameObject[] ObjectToEnable;

    Camera sceneCamera; 
    void Start ()
    {
        if (isLocalPlayer)
        {
            for (int i=0; i < componentsToEnable.Length;i++)
            {
                componentsToEnable[i].enabled = true;
            }
        }
        else
        {
            for (int i = 0; i < ObjectToDisable.Length; i++)
            {
                var rend = ObjectToDisable[i].GetComponent<Renderer>();
                rend.enabled = true;
            }
            sceneCamera = Camera.main;
            if (sceneCamera!=null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
        }
    }
    void OnDisable()
    {
        if  (sceneCamera!=null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }
        
}
