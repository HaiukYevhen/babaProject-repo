using Assets.Scripts.CommandParsers;
using Assets.Scripts.Interfaces;
using System.Linq;

namespace Assets.Scripts
{
	public class ISCommand : Command
	{
		public override void Execute(TreeNode node)
		{
			var filter = node.Nodes.FirstOrDefault()?.Value as IGameObjectFilter;
			var action = node.Nodes.LastOrDefault()?.Value as IGameObjectAction;

			if (filter == null || action == null)
				return;

			var targets = filter.GetGameObjects();

			foreach (var target in targets)
			{
				action.Apply(target);
			}
		}

		public override void Undo(TreeNode node)
		{
			var filter = node.Nodes.FirstOrDefault()?.Value as IGameObjectFilter;
			var action = node.Nodes.LastOrDefault()?.Value as IGameObjectAction;

			if (filter == null || action == null)
				return;

			var targets = filter.GetGameObjects();

			foreach (var target in targets)
			{
				action.Undo(target);
			}
		}
	}
}
