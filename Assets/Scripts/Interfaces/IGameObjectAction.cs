using Assets.Scripts.CommandParsers;

namespace Assets.Scripts.Interfaces
{
	public interface IGameObjectAction
	{
		void Apply(TreeNode node, CommandTarget target);
		void Undo(TreeNode node, CommandTarget target);
	}
}
