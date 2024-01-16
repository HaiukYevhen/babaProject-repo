using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using TreeEditor;
using UnityEngine;

namespace Assets.Scripts{
    public class PushCommand : Command, IGameObjectAction
    {
        public void Apply(GameObject target)
		{
            Debug.Log("Apply PushCommand");
            var m_Rigidbody = target.GetComponent<Rigidbody>();
            
            m_Rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionX;
            m_Rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;
            m_Rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionZ;
		}

		public void Undo(GameObject target)
		{
			Debug.Log("Undo PushCommand");
			var m_Rigidbody = target.GetComponent<Rigidbody>();

			m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		}
    }
}
