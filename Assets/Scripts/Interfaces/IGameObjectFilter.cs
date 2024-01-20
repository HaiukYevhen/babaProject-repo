using Assets.Scripts.CommandParsers;
using System.Collections.Generic;

namespace Assets.Scripts.Interfaces
{
	public interface IGameObjectFilter
	{
		IEnumerable<CommandTarget> GetCommandTargets(TreeNode node);
	}
}
