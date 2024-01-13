using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class BarrelCommand : Command, IGameObjectFilter, IGameObjectAction
	{
		public GameObject gameObjectBarrel;

		public IEnumerable<GameObject> GetGameObjects()
		{
			return GameObject.FindGameObjectsWithTag("Barrel");
		}

		public void Apply(GameObject target)
		{
			Vector3 gameObjectBarrelsPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
			Destroy(target);
			Instantiate(gameObjectBarrel, gameObjectBarrelsPosition, gameObjectBarrel.transform.rotation);
		}

		public void Undo(GameObject target)
		{
			
		}
	}
}
