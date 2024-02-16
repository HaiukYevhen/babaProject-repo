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
		public void Apply(TreeNode node, CommandTarget target)
		{
			Debug.Log("Apply Defeat");

			if (!target.HasTag("Defeat"))
			{
				target.AddComponent<Defeat>();
			}

			target.AddTag("Defeat");
		}
		public void Undo(TreeNode node, CommandTarget target)
		{
			Debug.Log("Undo Defeat");
			target.RemoveTag("Defeat");

			if (!target.HasTag("Defeat"))
			{
				var defeat = target.GetComponent<Defeat>();
				if (defeat != null)
				{
					Destroy(defeat);
				}
			}
		}
	}
}