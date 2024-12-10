using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 8;
	public float rotationSpeed = 720;
    private Rigidbody rb;
	// private GameObject e;
	private Animator playerAnimator;
	

    void Start()
    {
		rb = GetComponent<Rigidbody>();
		playerAnimator = GetComponent<Animator>();
	}

	void Update()
	{
		horizontalInput = Input.GetAxis("Horizontal");		
		verticalInput = Input.GetAxis("Vertical");
		MovementAnimation();
		MovementDirection();
    }

	// Update is called once per frame
	void FixedUpdate()
    {
		Vector3 position = rb.velocity;
		position.x = horizontalInput;
		position.z = verticalInput;

		if (position.y > 0)
			position.y = 0;

		if (position.magnitude > 1)
			position.Normalize();

		rb.velocity = position * speed;
	}

	void MovementAnimation()
	{
		if((horizontalInput >= 0.01f || verticalInput >= 0.01f || horizontalInput <= -0.01f || verticalInput <= -0.01f) && playerAnimator != null)
		{
			playerAnimator.SetFloat("Speed_f",0.3f);
			return;
		}
		if((horizontalInput == 0 || verticalInput == 0) && playerAnimator != null)
		{
			playerAnimator.SetFloat("Speed_f",0f);
		}
	}

	void MovementDirection()
	{
		Vector3 movementDirection = new Vector3 (horizontalInput, 0, verticalInput);
		movementDirection.Normalize();
		if(movementDirection != Vector3.zero)
		{
			Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
			// transform.forward = movementDirection;
		}
	}
}
