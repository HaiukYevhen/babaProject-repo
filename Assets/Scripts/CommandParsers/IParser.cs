using Assets.Scripts.Interfaces;
using System.Collections.Generic;

namespace Assets.Scripts.CommandParsers
{
	public interface IParser
	{
		public IParser Next { get; set; }
		IEnumerable<TreeNode> Parse(List<ICommand> nodes);
	}
}
