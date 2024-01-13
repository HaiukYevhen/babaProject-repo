using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.CommandParsers
{
	public class TreeNode
	{
		public ICommand Value { get; set; }
		public IEnumerable<TreeNode> Nodes { get; set; } = new List<TreeNode>();

		public override string ToString()
		{
			var str = Value?.Value ?? "_";
			if (Nodes.Any())
				str += $"({string.Join(";", Nodes)})";
			return str;
		}
	}
}
