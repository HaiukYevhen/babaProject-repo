using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Command : MonoBehaviour
{
    public Command left;
    public Command right;
    public Command top;
    public Command bottom;
    private CodeManagerController CodeManagerControllerScript;

    public string text;
    // Start is called before the first frame update
    void Start()
    {
        CodeManagerControllerScript = GameObject.Find("CodeManager").GetComponent<CodeManagerController>();
        Debug.Log(CodeManagerControllerScript);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LeftTriggerEnter(GameObject gameObjectTrigger)
    {
        var command = gameObjectTrigger.GetComponent<Command>();


        if(command != null)
        {
            left = command;
            command.right = this;
            CodeManagerControllerScript.Execute(GetLineHorizontal());
        }
    }
    public void LeftTriggerExit(GameObject gameObjectTrigger)
    {
        var command = gameObjectTrigger.GetComponent<Command>();


        if(command != null)
        {
            left = null;
            command.right = null;

            //PrintLine();
        //Debug.Log("LeftTriggerExit: "+command.text);
        }
    }
     public void TopTriggerEnter(GameObject gameObjectTrigger)
    {
        var command = gameObjectTrigger.GetComponent<Command>();
        if(command != null)
        {
            top = command;
            command.bottom = this;
            CodeManagerControllerScript.Execute(GetLineVertical());
            // PrintLineVertical();
            ///
        }
        
    }
    public void TopTriggerExit(GameObject gameObjectTrigger)
    {
        var command = gameObjectTrigger.GetComponent<Command>();

        if(command != null)
        {
            top = null;
            command.bottom = null;
        }
    }

    private List<string> GetLineHorizontal(){
        Command first = this;
        while (first.left != null)
            first = first.left;
        
        List<string> line = new List<string>();

        Command current = first;

        while (current != null){
            line.Add(current.text);
            current = current.right;
        }

        Debug.Log(string.Join(" -> ", line));
        return line;
    }
    private List<string> GetLineVertical()
    {
        Command first = this;
        while(first.top != null)
        {
            first = first.top;
        }
        List<string> line = new List<string>();

        Command current = first; 

        while (current != null)
        {
            line.Add(current.text);
            current = current.bottom;
        }
        Debug.Log(string.Join(" \\/ ", line));
        return line;
    }

}
