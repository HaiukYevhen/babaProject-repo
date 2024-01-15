using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.CommandParsers
{
	public class SimpleNodeParser : IParser
	{
		public string Token { get; set; }
		public IParser Next { get; set; }

		public SimpleNodeParser(string token)
		{
			Token = token;
		}
		public IEnumerable<TreeNode> Parse(List<ICommand> nodes)
		{
			var res = new List<TreeNode>();

			if (nodes.Count != 1)
				return res;

			res.Add(new TreeNode()
			{
				Value = nodes.First()
			});

			return res;
		}
	}
}
