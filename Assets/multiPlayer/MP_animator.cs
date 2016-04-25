using UnityEngine;
using System.Collections;

public class MP_animator : MonoBehaviour
{
    Animator anim;
    public float v; //Vertical
    public float h; //Horizontal
    public float sprint; // Sprint
                  // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        Sprinting();
    }
    void FixedUpdate()
    {
        anim.SetFloat("Walk", v);
        anim.SetFloat("Turn", h);
        anim.SetFloat("Sprint", sprint);
    }
    void Sprinting()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprint = 0.2f;
        }
        else
        {
            sprint = 0.0f;
        }
    }
}
