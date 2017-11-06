using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movSpeed;
    public float jumForce;
    public float mouseSensitivity;
    public GameObject c1;

    bool isGateOpener;


    public int isGrounded;

    float rotX;
    float rotY;

    private Rigidbody rb;

    


	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
 
	}
	

	void Update () {



        rotX = Input.GetAxis("Mouse X")*mouseSensitivity;
        rotY = Input.GetAxis("Mouse Y")*mouseSensitivity ;

        transform.Rotate(0,rotX, 0);
        c1.transform.Rotate(-rotY, 0, 0);

        rb.WakeUp();

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, movSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -movSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-movSpeed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(movSpeed * Time.deltaTime, 0, 0));
        }
        if (isGrounded == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0, jumForce, 0), ForceMode.Impulse);
                isGrounded = 0;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = 1;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GateOpener"))
        {
            isGateOpener = true;
            Destroy(other.gameObject);
        }
    }

}
