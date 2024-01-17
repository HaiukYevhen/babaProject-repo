using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;

    public bool canMove = false;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        Move(canMove);
    }
    public void Move(bool canMove)
    {
        if(canMove == true)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
            transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        }
    }
}
