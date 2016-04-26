using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float jumpForce = 5f;


    [SerializeField]
    private Camera playerView;

    [SerializeField]
    private float mouseSensivity = 3f;

	[SerializeField]
	private float sprintCoeff = 0.2f;

    Rigidbody rb;
    Vector3 velocity = Vector3.zero;
    Vector3 rotation = Vector3.zero;

	Animator anim;

	#region : sprint stuff

	[SerializeField]
	float stamina = 5, MaxStamina = 5;

	Rect staminaRec;
	Texture2D staminaTexture;


	#endregion

    float cameraRotationX = 0f;
    float currentCameraRotationX = 0f;

    [SerializeField]
    private float maxCameraRotation = 85f;

	void Start () 
    {
        rb = GetComponent<Rigidbody>();

		//instantiation for the stamina : size, texture, color
		staminaRec = new Rect (Screen.width / 10, Screen.height * 9 / 10, Screen.width / 3, Screen.height / 50);
		staminaTexture = new Texture2D (1, 1);
		staminaTexture.SetPixel (0, 0, Color.grey);
		staminaTexture.Apply ();

		anim = GetComponent<Animator>();
	}

	void Update () 
    {

        float movX = Input.GetAxisRaw("Horizontal");
        float movZ = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * movX;
        Vector3 moveVertical = transform.forward * movZ;

		#region : Sprint and Stamina Bar
		float _sprintcoeff;

		if (Input.GetKey (KeyCode.LeftShift)) 
		{
			_sprintcoeff = sprintCoeff;
			//anim.SetBool("IsRunning", true);
			stamina -= Time.deltaTime;
			if (stamina < 0) {
				stamina = 0;
				_sprintcoeff = 1f;
				//anim.SetBool("IsRunning", false);
			}
			
		} 
		else 
		{
			_sprintcoeff = 1f;
			//anim.SetBool("IsRunning", false);
			if (stamina < MaxStamina)
				stamina += Time.deltaTime;
		}
		#endregion

		//toMove
		velocity = (moveHorizontal + moveVertical).normalized * speed * _sprintcoeff;

		#region : Camera rotation
        float movY = Input.GetAxisRaw("Mouse X");
		Vector3 rot = new Vector3(0f, movY, 0f)* mouseSensivity;

        rotation = rot;

        float rotX = Input.GetAxisRaw("Mouse Y");
        float crX = rotX * mouseSensivity;

        cameraRotationX = crX;
		#endregion

		#region : Jump stuff
        float _jump;
        if (Input.GetButton("Jump"))
        {
			//anim.SetBool("IsJumping", true);
            _jump = jumpForce;
        }
        else
        {
			//anim.SetBool("IsJumping", false);
            _jump = 0f;
        }

        velocity.y = _jump;
		#endregion
	}

    void FixedUpdate()
    {
        PerformMove();
        PerformRotation();
    }

	#region : PerformMove
    private void PerformMove()
    {
		if (velocity != Vector3.zero) 
		{
			rb.MovePosition (rb.position + velocity  * Time.fixedDeltaTime);
			anim.SetBool ("IsMoving", true);
			//Debug.Log ("Satus of IsMoving : " + anim.GetBool ("IsMoving") + "");
		} 
		/*else 
		{
			anim.SetBool ("IsMoving", false);
			Debug.Log ("Satus of IsMoving" + anim.GetBool ("IsMoving") + "");
		}*/
    }
	#endregion

	#region : PerformRotation
    public void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (playerView != null)
        {
            currentCameraRotationX -= cameraRotationX;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -maxCameraRotation, maxCameraRotation);

            playerView.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
        }
    }
	#endregion

	void OnGUI()
	{
		//Compute the ratio
		float staminaRatio = stamina / MaxStamina;

		//the bar progression by the rect size
		float RectWidth = staminaRatio * Screen.width * 1 / 3;
		staminaRec.width = RectWidth;

		//Draw the bar
		GUI.DrawTexture(staminaRec, staminaTexture);

		GUI.Label (new Rect (450, 5, 30, 30), GameVariables.nbcoin + "");
	}
}
