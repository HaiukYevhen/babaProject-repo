using Assets.Scripts.CommandParsers;
using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour, ICommand
{
    public Command left;
    public Command right;
    public Command top;
    public Command bottom;
    private CodeManagerController CodeManagerControllerScript;

    public string text;

	public string Value => text;

	// Start is called before the first frame update
	void Start()
    {
        //Test Comment
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
            CodeManagerControllerScript.ExecuteCommands(GetLineHorizontal());
        }
    }
    public void LeftTriggerExit(GameObject gameObjectTrigger)
    {
        var command = gameObjectTrigger.GetComponent<Command>();

        if(command != null)
        {
			//заповнити commandsBefore, commandsAfterLeft, commandsAfterRight
			left = null;
            command.right = null;
            //CodeManagerControllerScript.UpdateCommands(commandsBefore, commandsAfterLeft, commandsAfterRight);
		}
    }
     public void TopTriggerEnter(GameObject gameObjectTrigger)
    {
        var command = gameObjectTrigger.GetComponent<Command>();
        if(command != null)
        {
            top = command;
            command.bottom = this;
            CodeManagerControllerScript.ExecuteCommands(GetLineVertical());
        }
        
    }
    public void TopTriggerExit(GameObject gameObjectTrigger)
    {
        var command = gameObjectTrigger.GetComponent<Command>();

        if(command != null)
        {
			//заповнити commandsBefore, commandsAfterLeft, commandsAfterRight
			top = null;
            command.bottom = null;
			//CodeManagerControllerScript.UpdateCommands(commandsBefore, commandsAfterLeft, commandsAfterRight);
		}
	}

    private List<ICommand> GetLineHorizontal(){
        Command first = this;
        while (first.left != null)
            first = first.left;
        
        List<ICommand> line = new List<ICommand>();

        Command current = first;

        while (current != null){
            line.Add(current);
            current = current.right;
        }

        Debug.Log(string.Join(" -> ", line));
        return line;
    }
    private List<ICommand> GetLineVertical()
    {
        Command first = this;
        while(first.top != null)
        {
            first = first.top;
        }
        List<ICommand> line = new List<ICommand>();

        Command current = first; 

        while (current != null)
        {
            line.Add(current);
            current = current.bottom;
        }
        Debug.Log(string.Join(" \\/ ", line));
        return line;
    }

	public virtual void Execute(TreeNode node)
	{

	}

	public virtual void Undo(TreeNode node)
	{
		
	}
}
