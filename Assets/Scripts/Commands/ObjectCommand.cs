﻿using Assets.Scripts.CommandParsers;
using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Commands
{
	public class ObjectCommand : Command, IGameObjectFilter, IGameObjectAction
	{
		public CommandTarget prefab;

		public IEnumerable<CommandTarget> GetGameObjects(TreeNode node)
		{
			return codeManagerController
				.GetCommandTargets()
				.Where(x => x.HasTag(this.text));
		}

		public void Apply(CommandTarget target)
		{
			Vector3 targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
			codeManagerController.DestroyCommandTarget(target);
			codeManagerController.InstantiateCommandTarget(prefab, targetPosition, prefab.transform.rotation);
		}

		public void Undo(CommandTarget target)
		{
			
		}
	}
}
