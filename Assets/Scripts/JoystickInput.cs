using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class JoystickInput : MonoBehaviour
{
    public Vector2 movementInput;
    public void OnMove(InputValue value)
    {
        Debug.Log("value.Get<Vector2>() : " + value.Get<Vector2>());
        movementInput = value.Get<Vector2>(); // ????????? ???????? ????
    }

    //public Vector2 movementInput;

    //public void OnMove(InputValue value)
    //{
    //    Debug.Log("value.Get<Vector2>() : " + value.Get<Vector2>());
    //    movementInput = value.Get<Vector2>();
    //}

    //public Vector2 GetMovementInput()
    //{
    //    return movementInput;
    //}
}
