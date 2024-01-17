using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
	public class RockCommand : Command, IGameObjectFilter, IGameObjectAction
	{
		public CommandTarget gameObjectRock;

		public IEnumerable<CommandTarget> GetGameObjects()
		{
			return CodeManagerControllerScript
				.GetCommandTargets()
				.Where(x => x.HasTag("Rock"));
		}

		public void Apply(CommandTarget target)
		{
			Vector3 gameObjectBarrelsPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
			CodeManagerControllerScript.DestroyCommandTarget(target);
			CodeManagerControllerScript.InstantiateCommandTarget(gameObjectRock, gameObjectBarrelsPosition, gameObjectRock.transform.rotation);
		}

		public void Undo(CommandTarget target)
		{
			
		}
	}
}
