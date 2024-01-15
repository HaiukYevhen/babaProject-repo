using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using TreeEditor;
using UnityEngine;

namespace Assets.Scripts{
    public class PushCommand : Command, IGameObjectFilter, IGameObjectAction
    {
        // 
        Rigidbody m_Rigidbody;

         public IEnumerable<GameObject> GetGameObjects()
		{
			return GameObject.FindGameObjectsWithTag("Wall");
		}
        
        public void Apply(GameObject target)
		{
            m_Rigidbody = target.GetComponent<Rigidbody>();
            // turn off FreezePositionX,FreezePositionY,FreezePositionZ
            m_Rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionX;
            m_Rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;
            m_Rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionZ;
            
		}
       

		public void Undo(GameObject target)
		{
			
		}
    }
}
