//BEHAN REMOSHAN
//17-06-2016 
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class MP_PlayerController : NetworkBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public Camera playerCamera;
    public GameObject bulletSound;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;


    //Animator
    Animator anim;
    public float walk; //Vertical
    public float turn; //Horizontal
    public float sprint; // Sprint
    public float fire; // Fire

    void Start()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        //Animator
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

        if (!isLocalPlayer)
        {
            return;
        }

        walk = Input.GetAxis("Vertical");
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 2.0f;
        var z = 0f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprint = 0.2f;
             z = walk * Time.deltaTime * 4.0f;
        }
        else
        {
            sprint = 0.0f;
             z = walk * Time.deltaTime * 2.0f;
        }

        //walk = z;

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(0, yaw, 0.0f);
        playerCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        //transform.forward = playerCamera.transform.forward;
        transform.Translate(x, 0, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            fire = 1f;
            CmdFire();
        }
        else
        {
            fire = 0.5f;
        }
    }
    void FixedUpdate()
    {
        anim.SetFloat("Walk", walk);
        anim.SetFloat("Turn", turn);
        anim.SetFloat("Sprint", sprint);
        anim.SetFloat("Fire", fire);
    }
    public override void OnStartLocalPlayer()
    {
        // GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    [Command]
    void CmdFire()
    {

        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        //Sound
        var holdSound = (GameObject)Instantiate(bulletSound, bulletSpawn.position, bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 30;

        // Spawn the bullet on the Clients
        NetworkServer.Spawn(bullet);
        NetworkServer.Spawn(holdSound);

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
        Destroy(holdSound, 2.0f);

    }
}