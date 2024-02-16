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
		public void Apply(TreeNode node, CommandTarget target)
		{
			Debug.Log("Apply Win");

			if (!target.HasTag("Win"))
			{
				target.AddComponent<Win>();
			}

			target.AddTag("Win");
		}
		public void Undo(TreeNode node, CommandTarget target)
		{
			Debug.Log("Undo Win");
            target.RemoveTag("Win");

			if (!target.HasTag("Win"))
			{
				var win = target.GetComponent<Win>();
				if (win != null)
				{
					Destroy(win);
				}
			}
		}
	}
}
