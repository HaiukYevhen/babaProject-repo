using Assets.Scripts.CommandParsers;
using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Commands
{
	public class Command : MonoBehaviour, ICommand
	{
		public Command left;
		public Command right;
		public Command top;
		public Command bottom;

		protected CodeManagerController codeManagerController;

		public string text;

		public string Value => text;

		// Start is called before the first frame update
		void Start()
		{
			codeManagerController = GameObject.Find("CodeManager").GetComponent<CodeManagerController>();
		}

		// Update is called once per frame
		void Update()
		{

		}
		public void LeftTriggerEnter(GameObject gameObjectTrigger)
		{
			var command = gameObjectTrigger.GetComponent<Command>();

			if (command != null)
			{
				if (this.left != null)
				{
					LeftTriggerExit(this.left.gameObject);
				}

				if (command.right != null)
				{
					command.right.LeftTriggerExit(command.gameObject);
				}

				this.left = command;
				command.right = this;
				codeManagerController.ExecuteCommands(GetLineHorizontal());
			}
		}
		public void LeftTriggerExit(GameObject gameObjectTrigger)
		{
			var command = gameObjectTrigger.GetComponent<Command>();

			if (command != null && this.left != null && command.right != null)
			{
				List<ICommand> commandsBefore = GetLineHorizontal();
				List<ICommand> commandsAfterLeft = new List<ICommand>();
				Command current = command;

				while (current != null)
				{
					commandsAfterLeft.Insert(0, current);
					current = current.left;
				}

				List<ICommand> commandsAfterRight = new List<ICommand>();
				current = this;

				while (current != null)
				{
					commandsAfterRight.Add(current);
					current = current.right;
				}

				this.left = null;
				command.right = null;

				codeManagerController.UpdateCommands(commandsBefore, commandsAfterLeft, commandsAfterRight);
			}
		}
		public void TopTriggerEnter(GameObject gameObjectTrigger)
		{
			var command = gameObjectTrigger.GetComponent<Command>();
			if (command != null)
			{
				if (this.top != null)
				{
					TopTriggerExit(this.top.gameObject);
				}

				if (command.bottom != null)
				{
					command.bottom.TopTriggerExit(command.gameObject);
				}

				top = command;
				command.bottom = this;
				codeManagerController.ExecuteCommands(GetLineVertical());
			}

		}
		public void TopTriggerExit(GameObject gameObjectTrigger)
		{
			var command = gameObjectTrigger.GetComponent<Command>();

			if (command != null && this.top != null && command.bottom != null)
			{
				List<ICommand> commandsBefore = GetLineVertical();
				List<ICommand> commandsAfterLeft = new List<ICommand>();
				Command current = command;

				while (current != null)
				{
					commandsAfterLeft.Insert(0, current);
					current = current.top;
				}

				List<ICommand> commandsAfterRight = new List<ICommand>();
				current = this;

				while (current != null)
				{
					commandsAfterRight.Add(current);
					current = current.bottom;
				}

				top = null;
				command.bottom = null;

				codeManagerController.UpdateCommands(commandsBefore, commandsAfterLeft, commandsAfterRight);
			}
		}

		private List<ICommand> GetLineHorizontal()
		{
			Command first = this;
			while (first.left != null)
				first = first.left;

			List<ICommand> line = new List<ICommand>();

			Command current = first;

			while (current != null)
			{
				line.Add(current);
				current = current.right;
			}

			//Debug.Log(string.Join(" -> ", line));
			return line;
		}
		private List<ICommand> GetLineVertical()
		{
			Command first = this;
			while (first.top != null)
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
			//Debug.Log(string.Join(" \\/ ", line));
			return line;
		}

		public virtual void Execute(TreeNode node)
		{

		}

		public virtual void Undo(TreeNode node)
		{

		}
	}
}
