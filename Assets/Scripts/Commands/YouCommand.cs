using Assets.Scripts.CommandParsers;
using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Commands
{
	public class YouCommand : Command, IGameObjectFilter, IGameObjectAction
	{
		public IEnumerable<CommandTarget> GetCommandTargets(TreeNode node)
		{
			return codeManagerController
				.GetCommandTargets()
				.Where(x => x.HasTag("You"));
		}

		public void Apply(TreeNode node, CommandTarget target)
		{
			Debug.Log("Apply You");
			if(!target.HasTag("You"))
			{
				target.AddComponent<Player>();
			}
			target.AddTag("You");
			
		}

		public void Undo(TreeNode node, CommandTarget target)
		{
			Debug.Log("Undo You");
			target.RemoveTag("You");

			if(!target.HasTag("You"))
			{
				if (codeManagerController.cameraController.followTarget == target)
				{
					codeManagerController.cameraController.SwitchCameraFollowTarget();
				}
				var player = target.GetComponent<Player>();
				if (player != null)
				{
					Destroy(player);
				}
			}

		}
	}
}
