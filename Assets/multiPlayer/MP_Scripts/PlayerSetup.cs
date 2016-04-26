using UnityEngine;
using UnityEngine.Networking;
public class PlayerSetup : NetworkBehaviour {
    [SerializeField]
    Behaviour[] compoToDisable;
    void Start ()
    {
        if (!isLocalPlayer)
        {
            for (int i=0; i < compoToDisable.Length;i++)
            {
                compoToDisable[i].enabled = false;
            }
        }
    }
        
}
