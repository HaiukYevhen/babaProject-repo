using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.CommandParsers
{
	public class RootParser : IParser
	{
		public List<string> RootNodes { get; set; }
		public RootParser(List<string> rootNodes)
		{
			RootNodes = rootNodes;
		}

		public IParser? Next { get; set; }

		public IEnumerable<TreeNode> Parse(List<ICommand> commandLine)
		{
			var commandLines = SplitLineByRootNodes(commandLine);

			List<TreeNode> result = new List<TreeNode>();

			foreach (var line in commandLines)
			{
				var tree = NextParse(line);
				result.AddRange(tree);
			}

			return result;
		}

		public List<List<ICommand>> SplitLineByRootNodes(List<ICommand> commandLine)
		{
			var splitIndexes = new List<int>();

			for (int i = 0; i < commandLine.Count; i++)
			{
				if (RootNodes.Any(x => x == commandLine[i].Value))
					splitIndexes.Add(i);
			}

			if (splitIndexes.Count == 0)
				return new List<List<ICommand>>();

			if (splitIndexes.Count == 1)
				return new List<List<ICommand>>()
				{
					commandLine
				};

			var result = new List<List<ICommand>>();

			splitIndexes.Insert(0, -1);
			splitIndexes.Add(commandLine.Count);

			var start = 0;
			var end = 0;

			for (int i = 1; i < splitIndexes.Count - 1; i++)
			{
				start = splitIndexes[i - 1] + 1;
				end = splitIndexes[i + 1];

				var line = commandLine
					.Skip(start)
					.Take(end - start)
					.ToList();

				result.Add(line);
			}

			return result;
		}

		private IEnumerable<TreeNode> NextParse(List<ICommand> nodes)
		{
			return Next?.Parse(nodes) ?? new List<TreeNode>();
		}
	}
}
