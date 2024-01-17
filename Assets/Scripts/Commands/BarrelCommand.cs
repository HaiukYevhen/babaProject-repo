using Assets.Scripts.CommandParsers;
using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Commands
{
	public class BarrelCommand : Command, IGameObjectFilter, IGameObjectAction
	{
		public CommandTarget gameObjectBarrel;

		public IEnumerable<CommandTarget> GetGameObjects(TreeNode node)
		{
			return CodeManagerControllerScript
				.GetCommandTargets()
				.Where(x => x.HasTag("Barrel"));
		}

		public void Apply(CommandTarget target)
		{
			Vector3 gameObjectBarrelsPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
			CodeManagerControllerScript.DestroyCommandTarget(target);
			CodeManagerControllerScript.InstantiateCommandTarget(gameObjectBarrel, gameObjectBarrelsPosition, gameObjectBarrel.transform.rotation);
		}

		public void Undo(CommandTarget target)
		{
			
		}
	}
}
