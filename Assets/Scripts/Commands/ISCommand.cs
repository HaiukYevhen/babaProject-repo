using Assets.Scripts.CommandParsers;
using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static CodeManagerController;

namespace Assets.Scripts.Commands
{
	public class ISCommand : Command
	{
		public override void Execute(TreeNode node)
		{
			TreeNode leftNode = node.Nodes.FirstOrDefault();
			TreeNode rightNode = node.Nodes.LastOrDefault();

			IGameObjectFilter filter = leftNode?.Value as IGameObjectFilter;
			IGameObjectAction action = rightNode?.Value as IGameObjectAction;

			if (filter == null || action == null)
				return;

			IEnumerable<CommandTarget> targets = filter
				.GetCommandTargets(leftNode)
				.Distinct()
				.ToList();

			foreach (CommandTarget target in targets)
			{
				action.Apply(rightNode, target);
			}

			codeManagerController.CommandTargetInstantiatedActions.Add(new CommandTargetActionDefenition
			{
				Key = node.GetId(),
				Action = (target) => ExecuteSingleTarget(node, target)
			});
		}

		public override void Undo(TreeNode node)
		{
			TreeNode leftNode = node.Nodes.FirstOrDefault();
			TreeNode rightNode = node.Nodes.LastOrDefault();

			IGameObjectFilter filter = leftNode?.Value as IGameObjectFilter;
			IGameObjectAction action = rightNode?.Value as IGameObjectAction;

			if (filter == null || action == null)
				return;

			IEnumerable<CommandTarget> targets = filter
				.GetCommandTargets(leftNode)
				.Distinct()
				.ToList();

			foreach (CommandTarget target in targets)
			{
				action.Undo(rightNode, target);
			}

			string key = node.GetId();
			codeManagerController.CommandTargetInstantiatedActions.RemoveAll(x => x.Key == key);
		}

		private void ExecuteSingleTarget(TreeNode node, CommandTarget target)
		{
			TreeNode leftNode = node.Nodes.FirstOrDefault();
			TreeNode rightNode = node.Nodes.LastOrDefault();

			IGameObjectFilter filter = leftNode?.Value as IGameObjectFilter;
			IGameObjectAction action = rightNode?.Value as IGameObjectAction;

			if (filter == null || action == null)
				return;

			IEnumerable<CommandTarget> targets = filter
						.GetCommandTargets(leftNode)
						.Distinct()
						.ToList();

			if (targets.Contains(target))
			{
				action.Apply(rightNode, target);
			}
		}
	}
}
