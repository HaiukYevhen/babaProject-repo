namespace Assets.Scripts.Interfaces
{
	public interface IGameObjectAction
	{
		void Apply(CommandTarget target);
		void Undo(CommandTarget target);
	}
}
