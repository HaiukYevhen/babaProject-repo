using UnityEngine;

namespace Assets.Scripts.Interfaces
{
	public interface IGameObjectAction
	{
		void Apply(GameObject target);
		void Undo(GameObject target);
	}
}
