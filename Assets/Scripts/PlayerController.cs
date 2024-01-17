using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;

    private Rigidbody rb;

    //public bool canMove = false;
    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(true);
    }
    public void Move(bool canMove)
    {
        if(canMove == true)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

			Vector3 position = rb.position;
			position.x += horizontalInput * speed * Time.deltaTime;
			position.z += verticalInput * speed * Time.deltaTime;
			rb.MovePosition(position);
        }
    }
}
