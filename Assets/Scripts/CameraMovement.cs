using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    [SerializeField]
	private float speed = 2.0f;
	//private float zoomSpeed = 2.0f;
    private float nSpeed;
    float maxSpeed;

    public float minX = -360.0f;
	public float maxX = 360.0f;
	
	public float minY = -45.0f;
	public float maxY = 45.0f;

	public float sensX = 100.0f;
	public float sensY = 100.0f;
	
	float rotationY = 0.0f;
	float rotationX = 0.0f;

    public Transform CharMesh;

    void Start()
    {
        nSpeed = speed;
        maxSpeed = speed + 100;
    }

	void Update ()
    {
        speed = nSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
            speed = maxSpeed;
        
		//float scroll = Input.GetAxis("Mouse ScrollWheel");
		//transform.Translate(0, scroll * zoomSpeed, scroll * zoomSpeed, Space.World);

		if (Input.GetKey(KeyCode.RightArrow)){
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow)){
            Vector3 mover= new Vector3 (Camera.main.transform.forward.x, 0,Camera.main.transform.forward.z);
            transform.position = transform.position + mover * speed * Time.deltaTime;
            
            print(Camera.main.transform.forward);
            //transform.position += Vector3.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			transform.position += Vector3.back * speed * Time.deltaTime;
		}

		//if (Input.GetMouseButton (0)) {
			rotationX += Input.GetAxis ("Mouse X") * sensX * Time.deltaTime;
			rotationY += Input.GetAxis ("Mouse Y") * sensY * Time.deltaTime;
			rotationY = Mathf.Clamp (rotationY, minY, maxY);
			transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
		//}
	}
}
