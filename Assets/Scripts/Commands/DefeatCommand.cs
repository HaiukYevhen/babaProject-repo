using Assets.Scripts.CommandParsers;
using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Commands
{
public class DefeatCommand : Command, IGameObjectAction
	{

	void Start()
	{
		codeManagerController = GameObject.Find("CodeManager").GetComponent<CodeManagerController>();
	}
		public void Apply(TreeNode node, CommandTarget target)
		{
            // codeManagerController.DestroyCommandTarget(target);
            target.AddTag("Defeat");
            target.AddComponent<Defeat>();
            Debug.Log("Apply DefeatCommand");
		}
		public void Undo(TreeNode node, CommandTarget target)
		{
			Debug.Log("Undo DefeatCommand");
            target.RemoveTag("Defeat");

            var defeat = target.GetComponent<Defeat>();

            if(defeat != null)
            {
                Destroy(defeat);
            }
		}
	}
}