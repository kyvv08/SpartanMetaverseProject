using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3f;
    private bool isMoving = true;
    [SerializeField]
    private float moveRange = 3f;

    private float direction = 1f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (isMoving)
        {
            float moveOffset = Mathf.PingPong(Time.time * moveSpeed, moveRange * 2) - moveRange;
            transform.position = new Vector3(startPos.x + moveOffset, transform.position.y, transform.position.z);
        }
    }

    public void Stop()
    {
        isMoving = false;
    }
}
