using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour
{
    public Transform target;
    float posX;
    float posY;
    float posZ;
    void Start()
    {
        if (target == null)
            return;

        posX = target.position.x;
        posY = target.position.y;
        posZ = -10f;
        transform.position = new Vector3(posX, posY, posZ);
    }

    void Update()
    {
        if (target == null)
            return;
        Vector3 pos = transform.position;
        pos.x = target.position.x;
        pos.y = target.position.y;
       transform.position = pos;
    }
}
