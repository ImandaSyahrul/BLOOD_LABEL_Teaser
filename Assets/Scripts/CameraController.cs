using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject followTarget;
	private Vector3 targetPos;
	public float moveSpeed;
    public CameraBoundaries cameraBoundaries;

    // Start is called before the first frame update
    void Start()
    {
        cameraBoundaries = GameObject.Find("CameraBoundaries").GetComponent<CameraBoundaries>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position != followTarget.transform.position)
        {
            targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, -10f);

            targetPos.x = Mathf.Clamp(targetPos.x, cameraBoundaries.minPosition.x, cameraBoundaries.maxPosition.x);
            targetPos.y = Mathf.Clamp(targetPos.y, cameraBoundaries.minPosition.y, cameraBoundaries.maxPosition.y);

            if (followTarget.CompareTag("Player"))
            {
                transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, targetPos, 0.1f);
            }
            
        }
		
        //transform.position = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, -10f);
    }

    public void FindPlayer()
    {
        followTarget = GameObject.Find("Player");
    }

    public void SetFollowTarget(GameObject toFollow)
    {
        followTarget = toFollow;
    }
}
