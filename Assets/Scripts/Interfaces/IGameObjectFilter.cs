using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
	public interface IGameObjectFilter
	{
		IEnumerable<GameObject> GetGameObjects();
	}
}
