//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Block : MonoBehaviour
//{
//    [SerializeField]
//    private float moveSpeed = 3f;
//    private bool isMoving = true;
//    [SerializeField]
//    private float moveRange = 3f;

//    private int direction = 1;
//    private float startX;
//    void Start()
//    {
//        startX = 6f;
//    }

//    void Update()
//    {
//        if (!isMoving) return;

//        float newX = transform.localPosition.x + direction * moveSpeed * Time.deltaTime;
//        if (Mathf.Abs(newX - startX) > moveRange)
//        {
//            direction *= -1; // 반대 방향으로
//            newX = Mathf.Clamp(newX, startX - moveRange, startX + moveRange);
//        }

//        transform.localPosition = new Vector3(newX, transform.localPosition.y, 0);
//    }

//    public void Stop()
//    {
//        isMoving = false;
//    }
//    public float GetXPosition()
//    {
//        return transform.localPosition.x;
//    }
//}
