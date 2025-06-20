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
	//private Vector2 movementInput;
	float finalX;
	float finalZ;
	//[SerializeField] private InputActionReference moveActionToUse;
	private JoystickInput joystickInput;

    void Start()
	{
		rb = GetComponent<Rigidbody>();
		playerAnimator = GetComponent<Animator>();
		joystickInput = GameObject.Find("MoveJoystick")?.GetComponent<JoystickInput>();
    }

	void Update()
	{
		horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


        //finalX = joystickInput.movementInput.x != 0 ? joystickInput.movementInput.x : horizontalInput;
        //      finalZ = joystickInput.movementInput.y != 0 ? joystickInput.movementInput.y : verticalInput;
        float joystickX = joystickInput != null ? joystickInput.movementInput.x : 0f;
        float joystickY = joystickInput != null ? joystickInput.movementInput.y : 0f;

        finalX = Mathf.Abs(joystickX) > 0.01f ? joystickX : horizontalInput;
        finalZ = Mathf.Abs(joystickY) > 0.01f ? joystickY : verticalInput;

        MovementAnimation(finalX, finalZ);
		MovementDirection(finalX, finalZ);
	}
	// Update is called once per frame
	void FixedUpdate()
	{
		Vector3 position = rb.velocity;
		position.x = finalX;
		position.z = finalZ;

		if (position.y > 0)
			position.y = 0;

		if (position.magnitude > 1)
			position.Normalize();

		rb.velocity = position * speed;
	}

	void MovementAnimation(float x, float z)
	{
        //if ((horizontalInput >= 0.01f || verticalInput >= 0.01f || horizontalInput <= -0.01f || verticalInput <= -0.01f) && playerAnimator != null)
        //{
        //	playerAnimator.SetFloat("Speed_f", 0.3f);
        //	return;
        //}
        //if ((horizontalInput == 0 || verticalInput == 0) && playerAnimator != null)
        //{
        //	playerAnimator.SetFloat("Speed_f", 0f);
        //}

        if ((x != 0 || z != 0) && playerAnimator != null)
        {
            playerAnimator.SetFloat("Speed_f", 0.3f);
        }
        else if (playerAnimator != null)
        {
            playerAnimator.SetFloat("Speed_f", 0f);
        }
    }

	void MovementDirection(float x, float z)
	{
		Vector3 movementDirection = new Vector3(x, 0, z);
		movementDirection.Normalize();
		if (movementDirection != Vector3.zero)
		{
			Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
			// transform.forward = movementDirection;
		}
	}
	//public void OnMove(InputValue value)
	//{
	//	Debug.Log("value.Get<Vector2>() : " + value.Get<Vector2>());
	//	movementInput = value.Get<Vector2>(); // ????????? ???????? ????
	//}
}
