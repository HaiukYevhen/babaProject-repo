using Assets.Scripts.CommandParsers;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Commands
{
	public class PushCommand : Command, IGameObjectAction
    {
        public void Apply(TreeNode node, CommandTarget target)
		{
            Debug.Log("Apply PushCommand");
            var m_Rigidbody = target.GetComponent<Rigidbody>();

			m_Rigidbody.isKinematic = true;
		}

		public void Undo(TreeNode node, CommandTarget target)
		{
			Debug.Log("Undo PushCommand");
			var m_Rigidbody = target.GetComponent<Rigidbody>();
			m_Rigidbody.isKinematic = false;
		}
    }
}
