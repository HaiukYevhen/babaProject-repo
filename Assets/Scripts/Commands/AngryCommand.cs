using Assets.Scripts.CommandParsers;
using Assets.Scripts.Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


namespace Assets.Scripts.Commands
{ 
    public class AngryCommand : Command, IGameObjectAction
    {
        public void Apply(TreeNode node, CommandTarget target)
        {
            Debug.Log("Apply Angry");
            if (!target.HasTag("Angry"))
            {
                target.AddComponent<EnemyAi>();
                target.AddComponent<FieldOfView>();
            }

            target.AddTag("Angry");
        }
        public void Undo(TreeNode node, CommandTarget target)
        {
            Debug.Log("Undo Angry");
            target.RemoveTag("Angry");

            if (!target.HasTag("Angry"))
            {
                var enemyAi = target.GetComponent<EnemyAi>();
                var fieldOfView = target.GetComponent<FieldOfView>();
                if (enemyAi != null)
                {
                    Destroy(enemyAi);
                    Destroy(fieldOfView);
                    Destroy(target.GetComponent<NavMeshAgent>());
                }
            }
        }
    }
}

