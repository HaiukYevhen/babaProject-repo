using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.CommandParsers
{
	public class BinaryNodeParser : IParser
	{
		public string Token { get; set; }
		public IParser Next { get; set; }

		public BinaryNodeParser(string token)
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

			var left = nodes
					.Skip(0)
					.Take(tokenIndex)
					.ToList();

			var right = nodes
					.Skip(tokenIndex + 1)
					.Take(nodes.Count)
					.ToList();

			if (!left.Any() || !right.Any())
				return NextParse(nodes);

			var leftNode = NextParse(left);

			if (!leftNode.Any())
				return NextParse(nodes);

			var rightNode = NextParse(right);

			if (!rightNode.Any())
				return NextParse(nodes);

			var childrenNodes = new List<TreeNode>();
			childrenNodes.AddRange(leftNode);
			childrenNodes.AddRange(rightNode);

			node.Nodes = childrenNodes;

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
