using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CAMERA_MODE
{
    MAP,MINIGAME_STACK
}

public class CamerController : MonoBehaviour
{
    CAMERA_MODE mode { get; set; }

    public Transform target;
    private Transform target_player;
    float posX;
    float posY;
    float posZ;

    Vector3 StackPos = new Vector3(-30.5f, -7f,-10f);

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
        switch (mode) {
            case CAMERA_MODE.MAP:
                {
                    Vector3 pos = transform.position;
                    pos.x = Mathf.Clamp(target.position.x, minX, maxX);
                    pos.y = Mathf.Clamp(target.position.y, minY, maxY);
                    transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 5f);
                    break;
                }
            case CAMERA_MODE.MINIGAME_STACK:
                {
                    transform.position = StackPos;
                    break;
                }
        }
    }

    public void SwitchMode(CAMERA_MODE mode)
    {
        this.mode = mode;
    }
}
