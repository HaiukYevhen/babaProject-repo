using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.CommandParsers
{
	public class UnaryNodeParser : IParser
	{
		public string Token { get; set; }
		public IParser Next { get; set; }

		public UnaryNodeParser(string token)
		{
			Token = token;
		}
		public IEnumerable<TreeNode> Parse(List<ICommand> nodes)
		{
			var tokenIndex = nodes.FindIndex(x => x.Value == Token);

			if (tokenIndex == -1)
				return NextParse(nodes);

			var node = new TreeNode()
			{
				Value = nodes[tokenIndex]
			};

			var right = nodes
					.Skip(tokenIndex + 1)
					.Take(nodes.Count)
					.ToList();

			if (!right.Any())
				return NextParse(nodes);

			var rightNode = NextParse(right);

			if (!rightNode.Any())
				return NextParse(nodes);

			node.Nodes = rightNode;

			return new List<TreeNode>()
			{
				node
			};
		}

		private IEnumerable<TreeNode> NextParse(List<ICommand> nodes)
		{
			return Next?.Parse(nodes) ?? new List<TreeNode>();
		}
	}
}
