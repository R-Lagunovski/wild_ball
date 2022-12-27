using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
    public Transform[] CameraStopPoints;

    public float cameraSpeed;

    private bool forward;
    private Transform target;
    private int currentTargetIndex;
    // Start is called before the first frame update
    void Start()
    {
        forward = true;
        currentTargetIndex = 0;
        target = CameraStopPoints[1];
        transform.position = CameraStopPoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * cameraSpeed);
        if (transform.position == target.position)
            ChangeTarget();
    }

    //Change camera object target to next
    private void ChangeTarget()
    {
        if (forward)
        {
            currentTargetIndex += 1;
            if (currentTargetIndex == CameraStopPoints.Length)
                forward = !forward;
        }

        if (!forward)
        {
            currentTargetIndex -= 1;
            if (currentTargetIndex == 0)
                forward = !forward;
        }
        target = CameraStopPoints[currentTargetIndex];
    }
}
