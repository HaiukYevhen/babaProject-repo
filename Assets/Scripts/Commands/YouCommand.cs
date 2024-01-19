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
		public IEnumerable<CommandTarget> GetGameObjects(TreeNode node)
		{
			return codeManagerController
				.GetCommandTargets()
				.Where(x => x.HasTag("You"));
		}

		public void Apply(CommandTarget target)
		{
			Debug.Log("Apply You");
			target.AddTag("You");
			target.AddComponent<Player>();
		}

		public void Undo(CommandTarget target)
		{
			Debug.Log("Undo You");
			target.RemoveTag("You");
			var player = target.GetComponent<Player>();

			if (codeManagerController.cameraController.followTarget == target)
			{
				codeManagerController.cameraController.SwitchCameraFollowTarget();
			}

			if (player != null)
			{
				Destroy(player);
			}
		}
	}
}
