using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;
    private BallController player;

    //boundeies
    public float limitLeft, limitRight, limitBottom, limitTop;

    void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            player = target.GetComponent<BallController>();
        }
    }


    private void LateUpdate()
    {
        Transform currentTarget = target;
        Vector3 desirePosition = currentTarget.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desirePosition, ref velocity, smoothSpeed);
        //transform.position = smoothedPosition;

        //boundaries
        transform.position = new Vector3(Mathf.Clamp(smoothedPosition.x, limitLeft, limitRight), Mathf.Clamp(smoothedPosition.y, limitBottom, limitTop), smoothedPosition.z);
    }
}

