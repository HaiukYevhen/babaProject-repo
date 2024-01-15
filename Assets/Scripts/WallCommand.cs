
// WallCommand
using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using TreeEditor;
using UnityEngine;

namespace Assets.Scripts{
    public class WallCommand : Command, IGameObjectFilter, IGameObjectAction
    {
        public GameObject gameObjectWall;
        public IEnumerable<GameObject> GetGameObjects()
		{
			return GameObject.FindGameObjectsWithTag("Wall");
		}
        public void Apply(GameObject target)
		{
            Vector3 gameObjectgameObjectWallsPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
			Destroy(target);
			Instantiate(gameObjectWall, gameObjectgameObjectWallsPosition, gameObjectWall.transform.rotation);
		}

		public void Undo(GameObject target)
		{
			
		}
    }
}
