using Assets.Scripts.CommandParsers;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Commands
{
	public class HeavyCommand : Command, IGameObjectAction
    {
		float currentMass;
        public void Apply(TreeNode node, CommandTarget target)
		{
           
			// target.AddTag("Heavy");
            var m_Rigidbody = target.GetComponent<Rigidbody>();
			// currentMass = m_Rigidbody.mass;
			m_Rigidbody.mass += 10000;

			// m_Rigidbody.isKinematic = true;
		}

		public void Undo(TreeNode node, CommandTarget target)
		{
			// target.RemoveTag("Heavy");
			var m_Rigidbody = target.GetComponent<Rigidbody>();
			m_Rigidbody.mass -= 10000;
			// m_Rigidbody.isKinematic = false;
		}
    }
}
