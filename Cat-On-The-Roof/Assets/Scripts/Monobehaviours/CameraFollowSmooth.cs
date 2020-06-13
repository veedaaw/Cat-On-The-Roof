using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSmooth : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.2F;
    private Vector3 velocity = Vector3.zero;
    public float rotationSpeed =10f;

    Vector3 targetPosition;

    void Update()
    {
        // Define a target position above and behind the target transform

        targetPosition = target.TransformPoint(new Vector3(0, 0.4f, -1));
        // Smoothly move and rotate the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, rotationSpeed * Time.deltaTime);
    }
}
