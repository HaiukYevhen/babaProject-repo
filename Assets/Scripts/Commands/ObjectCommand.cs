using Assets.Scripts.CommandParsers;
using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Commands
{
	public class ObjectCommand : Command, IGameObjectFilter, IGameObjectAction
	{
		public CommandTarget prefab;

		public IEnumerable<CommandTarget> GetCommandTargets(TreeNode node)
		{
			return codeManagerController
				.GetCommandTargets()
				.Where(x => x.HasTag(this.text));
		}

		public void Apply(TreeNode node, CommandTarget target)
		{
			Vector3 targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
			codeManagerController.DestroyCommandTarget(target);
			codeManagerController.InstantiateCommandTarget(prefab, targetPosition, prefab.transform.rotation);

			if (target.GetComponent<Player>() != null) target.GetComponent<PlayerPickUpDrop>().ExtraDropObject();
		}

		public void Undo(TreeNode node, CommandTarget target)
		{
			
		}
	}
}
