using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.CommandParsers
{
	public class ParserBuilder
	{
		public static ParserBuilder Instance { get; } = new ParserBuilder()
			.AddParser(new RootParser(new List<string>()
			{
				"IS"
			}))
			.AddBinaryNodeParser("IS")
			.AddBinaryNodeParser("AND")
			.AddUnaryNodeParser("NOT")
			.AddSimpleNodeParser("*");

		private List<IParser> Parsers { get; set; } = new List<IParser>();

		public ParserBuilder AddBinaryNodeParser(string token)
		{
			var parser = new BinaryNodeParser(token);
			return AddParser(parser);
		}

		public ParserBuilder AddUnaryNodeParser(string token)
		{
			var parser = new UnaryNodeParser(token);
			return AddParser(parser);
		}

		public ParserBuilder AddSimpleNodeParser(string token)
		{
			var parser = new SimpleNodeParser(token);
			return AddParser(parser);
		}

		public ParserBuilder AddParser(IParser parser)
		{
			if (!Parsers.Any())
			{
				Parsers.Add(parser);
			}
			else
			{
				var last = Parsers.Last();
				last.Next = parser;
				Parsers.Add(parser);
			}

			return this;
		}

		public IParser GetParser()
		{
			return Parsers.First();
		}
	}
}
