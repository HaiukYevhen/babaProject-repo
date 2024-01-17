using UnityEngine;

namespace Assets.Scripts.Commands.CommandTriggers
{
	public class CommandLeftTrigger : MonoBehaviour
	{
		// Start is called before the first frame update
		public GameObject parentGameObject;
		public string textString;
		private Command parentComand;
		void Start()
		{
			parentComand = parentGameObject.GetComponent<Command>();
		}

		// Update is called once per frame
		void Update()
		{

		}
		void OnTriggerEnter(Collider collider)
		{
			parentComand.LeftTriggerEnter(collider.gameObject);
		}
		void OnTriggerExit(Collider collider)
		{
			parentComand.LeftTriggerExit(collider.gameObject);
		}
	}

}
