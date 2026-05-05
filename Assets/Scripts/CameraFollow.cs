using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public float yOffset = -0.5f;
    void LateUpdate()
    {
        float desiredY = target.position.y + yOffset;

        if (desiredY > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, desiredY, transform.position.z);
            transform.position = newPos;

        }

    }
}
