using UnityEngine;
using System.Collections;

public class MP_animator : MonoBehaviour
{
    Animator anim;
    public float walk; //Vertical
    public float turn; //Horizontal
    public float sprint; // Sprint
                  // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        walk = Input.GetAxis("Vertical");
        turn = Input.GetAxis("Horizontal");
        Sprinting();
    }
    void FixedUpdate()
    {
        anim.SetFloat("Walk", walk);
        anim.SetFloat("Turn", turn);
        anim.SetFloat("Sprint", sprint);
    }
    void Sprinting()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprint = 0.2f;
        }
        else
        {
            sprint = 0.0f;
        }
    }
}
