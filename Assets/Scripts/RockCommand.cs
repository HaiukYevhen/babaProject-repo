using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using TreeEditor;
using UnityEngine;

namespace Assets.Scripts
{
	public class RockCommand : Command, IGameObjectFilter, IGameObjectAction
	{
		public GameObject gameObjectRock;

		public IEnumerable<GameObject> GetGameObjects()
		{
			return GameObject.FindGameObjectsWithTag("Rock");
		}

		public void Apply(GameObject target)
		{
			Vector3 gameObjectBarrelsPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
			Destroy(target);
			Instantiate(gameObjectRock, gameObjectBarrelsPosition, gameObjectRock.transform.rotation);
		}

		public void Undo(GameObject target)
		{
			
		}
	}
}
