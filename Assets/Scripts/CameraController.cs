using Cinemachine;
using System.Linq;
using UnityEngine;
public class CameraController : MonoBehaviour
{
	protected CodeManagerController codeManagerController;
	public CommandTarget followTarget;

	private int i = 0 ;
    private GameObject camObj;
    private CinemachineVirtualCamera virtualCamera;

    void Start()
    {
		codeManagerController = GameObject.Find("CodeManager").GetComponent<CodeManagerController>();
		camObj = GameObject.Find("VirtualCamera1");
		virtualCamera = camObj.GetComponent<CinemachineVirtualCamera>();
	}

    public void SwitchCameraFollowTarget()
    {
		var players = codeManagerController
			.GetCommandTargets()
			.Where(x => x.HasTag("You"))
			.ToList();

		if (players.Count() == 0)
			return;

		i++;

		if (i >= players.Count())
			i = 0;

		followTarget = players[i];

		virtualCamera.transform.position = followTarget.transform.position;
		virtualCamera.Follow = followTarget.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown("space"))
		{
			SwitchCameraFollowTarget();
		}
    }
}
