using Assets.Scripts.CommandParsers;

namespace Assets.Scripts.Interfaces
{
	public interface ICommand
	{
		string Value { get; }
		void Execute(TreeNode node);

		void Undo(TreeNode node);
	}
}
