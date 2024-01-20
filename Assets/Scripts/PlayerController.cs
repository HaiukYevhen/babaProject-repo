using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;

    private Rigidbody rb;

    void Start()
    {
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");
	}

	// Update is called once per frame
	void FixedUpdate()
    {
		Vector3 position = rb.velocity;
		position.x = horizontalInput;
		position.z = verticalInput;

		if (position.magnitude > 1)
			position.Normalize();

		rb.velocity = position * speed;
	}
}
