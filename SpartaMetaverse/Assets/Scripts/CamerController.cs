using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour
{
    public Transform target;
    float posX;
    float posY;
    float posZ;

    float minX,maxX,minY,maxY;
    void Start()
    {
        if (target == null)
            return;

        maxX = 9.89f;
        minX = -maxX + 2;
        maxY = 7f;
        minY = -maxY + 1;

        Vector3 pos = target.position;
        pos.x = target.position.x;
        pos.y = target.position.y;
        pos.z = -10f;
        transform.position = pos;
    }

    void LateUpdate()
    {
        if (target == null)
            return;
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(target.position.x, minX, maxX);
        pos.y = Mathf.Clamp(target.position.y, minY, maxY);
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime* 5f);
    }
}
