using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
	public class WallCommand : Command, IGameObjectFilter, IGameObjectAction
    {
        public CommandTarget gameObjectWall;
        public IEnumerable<CommandTarget> GetGameObjects()
		{
			return CodeManagerControllerScript
				.GetCommandTargets()
				.Where(x => x.HasTag("Wall"));
		}
        public void Apply(CommandTarget target)
		{
            Vector3 gameObjectgameObjectWallsPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
			CodeManagerControllerScript.DestroyCommandTarget(target);
			CodeManagerControllerScript.InstantiateCommandTarget(gameObjectWall, gameObjectgameObjectWallsPosition, gameObjectWall.transform.rotation);
		}

		public void Undo(CommandTarget target)
		{
			
		}
    }
}
