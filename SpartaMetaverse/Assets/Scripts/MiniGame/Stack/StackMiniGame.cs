//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class StackMiniGame : MonoBehaviour, IMiniGame
//{
//    [SerializeField]
//    private GameObject block;
//    [SerializeField]
//    private GameObject stack;

//    private Camera camera;

//    private Block curBlock;
//    private Block prevBlock;
//    private Transform lastBlock;
//    private int stackHeight = 0;

//    private Vector3 desiredPos;
//    private Vector3 prevBlockPos = new Vector3(0,-3.25f,0);

//    int stackCount = 0;

//    float blockHeight = 0.5f;
//    float stackBounds = 10f;

//    bool isOver = false;
//    public void ShowOffUI() { }
//    public void StartMiniGame()
//    {   
//        camera = Camera.main;
//        camera.GetComponent<CamerController>().SwitchMode(CAMERA_MODE.MINIGAME_STACK);
//        SpawnBlock();
//        curBlock.Stop();
//        SpawnBlock();
//    }
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space) && curBlock != null)
//        {
//            curBlock.Stop();

//            float offset = curBlock.GetXPosition() - prevBlock.transform.localPosition.x;
//            float overhang = Mathf.Abs(offset);

//            if (overhang >= stackBounds)
//            {
//                Debug.Log("Game Over");
//                return;
//            }

//            SpawnBlock();
//        }
//    }

//    void SpawnBlock()
//    {
//        if (lastBlock != null)
//            prevBlockPos = lastBlock.localPosition;

        
//        GameObject newBlock = null;
//        Transform newTrans = null;

//        newBlock = Instantiate(block);

//        if (newBlock == null)
//        {
//            Debug.Log("NewBlock Instantiate Failed!");
//            return;
//        }

//        newTrans = newBlock.transform;
//        newTrans.parent = stack.transform;
//        newTrans.localPosition = prevBlockPos+new Vector3(0,0.5f,0);
//        newTrans.localScale = new Vector2(stackBounds,0.5f);

//        curBlock = newBlock.GetComponent<Block>();
//        lastBlock = newTrans;
//        prevBlockPos = newTrans.position;
//        stackCount++;
//    }
//    public void ShowUI()
//    {
//        Debug.Log("스택 미니 게임 설명");
//    }
////    void PlaceBlock()
////    {
////        float deltaX = prevBlockPos.x - lastPosition.x;
////        bool isNegativeNum = (deltaX < 0) ? true : false;

////        deltaX = Mathf.Abs(deltaX);
////        if (deltaX > ErrorMargin)
////        {
////            stackBounds.x -= deltaX;
////            if (stackBounds.x <= 0)
////            {
////                return false;
////            }

////            float middle = (prevBlockPosition.x + lastPosition.x) / 2;
////            lastBlock.localScale = new Vector3(stackBounds.x, 1, stackBounds.y);

////            Vector3 tempPosition = lastBlock.localPosition;
////            tempPosition.x = middle;
////            lastBlock.localPosition = lastPosition = tempPosition;

////            float rubbleHalfScale = deltaX / 2f;
////            CreateRubble(
////                new Vector3(isNegativeNum
////                        ? lastPosition.x + stackBounds.x / 2 + rubbleHalfScale
////                        : lastPosition.x - stackBounds.x / 2 - rubbleHalfScale
////                    , lastPosition.y
////                    , lastPosition.z),
////                new Vector3(deltaX, 1, stackBounds.y)
////            );
////        }
////        else
////        {
////            lastBlock.localPosition = prevBlockPosition + Vector3.up;
////        }
////}
//}