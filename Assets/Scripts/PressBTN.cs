using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressBTN : MonoBehaviour
{

    private bool ePressed = false;
    [SerializeField] private string buttonName = "EButton";

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => ePressed = true);
    }

    public bool EButtonActivation()
    {
        if (ePressed)
        {
            Debug.Log("BTN: " + GetButtonName());
            ePressed = false; // ???????? ????? ?????????
            return true;
        }
        return false;
    }
    public string GetButtonName()
    {
        return buttonName;
    }
    //public bool EButtonActivation() 
    //{
    //    Debug.Log("E");
    //    Input.GetKeyDown(KeyCode.E);
    //    return Input.GetKeyDown(KeyCode.E);
    //}
}
