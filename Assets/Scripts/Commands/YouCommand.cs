﻿using Assets.Scripts.CommandParsers;
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
				target.AddComponent<PlayerPickUpDrop>();
			}
			target.AddTag("You");

			if(target.gameObject.layer == LayerMask.NameToLayer("Default"))
				target.gameObject.layer = LayerMask.NameToLayer("Target");

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
                var PlayerPickUpDrop = target.GetComponent<PlayerPickUpDrop>();

                if (PlayerPickUpDrop != null)
                {
                    Destroy(PlayerPickUpDrop);
                }
                if (player != null)
				{
					Destroy(player);
				}
				if(target.gameObject.layer == LayerMask.NameToLayer("Target"))
					target.gameObject.layer = LayerMask.NameToLayer("Default");
            }

		}
	}
}
