using Assets.Scripts.CommandParsers;
using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
				.GetGameObjects()
				.ToList();

			foreach (CommandTarget target in targets)
			{
				action.Apply(target);
			}
		}

		public override void Undo(TreeNode node)
		{
			TreeNode left = node.Nodes.FirstOrDefault();
			TreeNode right = node.Nodes.LastOrDefault();

			IGameObjectFilter filter = left?.Value as IGameObjectFilter;
			IGameObjectAction action = right?.Value as IGameObjectAction;

			if (filter == null || action == null)
				return;

			IEnumerable<CommandTarget> targets = filter
				.GetGameObjects()
				.ToList();

			foreach (CommandTarget target in targets)
			{
				action.Undo(target);
			}
		}
	}
}
