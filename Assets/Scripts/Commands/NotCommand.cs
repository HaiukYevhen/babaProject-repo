using Assets.Scripts.CommandParsers;
using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Commands
{
	public class NotCommand : Command, IGameObjectFilter, IGameObjectAction
	{
		public IEnumerable<CommandTarget> GetCommandTargets(TreeNode node)
		{
			TreeNode childNode = node.Nodes.FirstOrDefault();
			IGameObjectFilter filter = childNode?.Value as IGameObjectFilter;

			if (filter == null) 
				return new List<CommandTarget>();

			List<CommandTarget> childTargets = filter
				.GetCommandTargets(childNode)
				.ToList();

			List<CommandTarget> allTargets = codeManagerController
				.GetCommandTargets()
				.ToList();

			return allTargets
				.Where(x => !childTargets.Contains(x));
		}

		public void Apply(TreeNode node, CommandTarget target)
		{
			//?
		}

		public void Undo(TreeNode node, CommandTarget target)
		{
			//?
		}
	}
}
