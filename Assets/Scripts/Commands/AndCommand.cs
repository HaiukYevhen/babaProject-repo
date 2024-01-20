using Assets.Scripts.CommandParsers;
using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Commands
{
	public class AndCommand : Command, IGameObjectFilter, IGameObjectAction
	{
		public IEnumerable<CommandTarget> GetCommandTargets(TreeNode node)
		{
			TreeNode leftNode = node.Nodes.FirstOrDefault();
			TreeNode rightNode = node.Nodes.LastOrDefault();

			IGameObjectFilter leftFilter = leftNode?.Value as IGameObjectFilter;
			IGameObjectFilter rightFilter = rightNode?.Value as IGameObjectFilter;

			if (leftFilter == null || rightFilter == null) 
				return new List<CommandTarget>();

			List<CommandTarget> leftTargets = leftFilter
				.GetCommandTargets(leftNode)
				.ToList();

			List<CommandTarget> rightTargets = rightFilter
				.GetCommandTargets(rightNode)
				.ToList();

			List<CommandTarget> allTargets = new List<CommandTarget>();
			allTargets.AddRange(leftTargets);
			allTargets.AddRange(rightTargets);

			return allTargets;
		}

		public void Apply(TreeNode node,CommandTarget target)
		{
			TreeNode leftNode = node.Nodes.FirstOrDefault();
			TreeNode rightNode = node.Nodes.LastOrDefault();

			IGameObjectAction leftAction = leftNode?.Value as IGameObjectAction;
			IGameObjectAction rightAction = rightNode?.Value as IGameObjectAction;

			if (leftAction == null || rightAction == null)
				return;

			leftAction.Apply(leftNode, target);
			rightAction.Apply(rightNode, target);
		}

		public void Undo(TreeNode node, CommandTarget target)
		{
			TreeNode leftNode = node.Nodes.FirstOrDefault();
			TreeNode rightNode = node.Nodes.LastOrDefault();

			IGameObjectAction leftAction = leftNode?.Value as IGameObjectAction;
			IGameObjectAction rightAction = rightNode?.Value as IGameObjectAction;

			if (leftAction == null || rightAction == null)
				return;

			leftAction.Undo(leftNode, target);
			rightAction.Undo(rightNode, target);
		}
	}
}
