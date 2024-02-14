using Assets.Scripts.CommandParsers;
using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Commands
{
public class WinCommand : Command, IGameObjectAction
	{

	// void Start()
	// {
	// 	codeManagerController = GameObject.Find("CodeManager").GetComponent<CodeManagerController>();
	// }
		public void Apply(TreeNode node, CommandTarget target)
		{
            // codeManagerController.DestroyCommandTarget(target);
			target.AddTag("Win");
            target.AddComponent<Win>();
            Debug.Log("Apply Win");
		}
		public void Undo(TreeNode node, CommandTarget target)
		{
			Debug.Log("Undo Win");
            target.RemoveTag("Win");
			var win = target.GetComponent<Win>();

            if(win != null)
            {
                Destroy(win);
            }
		}
	}
}
