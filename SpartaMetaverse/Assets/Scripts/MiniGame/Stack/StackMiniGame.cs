using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackMiniGame : MonoBehaviour, IMiniGame
{
    [SerializeField]
    private GameObject block;
    [SerializeField]
    private GameObject stack;

    private Camera camera;

    private Block curBlock;
    private Block prevBlock;
    private Transform lastBlock;
    private int stackHeight = 0;

    private Vector3 desiredPos;
    private Vector3 prevBlockPos = new Vector3(0,-3.25f,0);

    int stackCount = 0;

    float blockHeight = 0.5f;
    float stackBounds = 10f;

    bool isOver = false;
    public void StartMiniGame()
    {   
        camera = Camera.main;
        camera.GetComponent<CamerController>().SwitchMode(CAMERA_MODE.MINIGAME_STACK);
        SpawnBlock();
        SpawnBlock();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && curBlock != null)
        {
            curBlock.Stop();
            SpawnBlock();
        }
    }

    void SpawnBlock()
    {
        if (lastBlock != null)
            prevBlockPos = lastBlock.localPosition;

        
        GameObject newBlock = null;
        Transform newTrans = null;

        newBlock = Instantiate(block);

        if (newBlock == null)
        {
            Debug.Log("NewBlock Instantiate Failed!");
            return;
        }

        newTrans = newBlock.transform;
        newTrans.parent = stack.transform;
        newTrans.localPosition = prevBlockPos+new Vector3(0,0.5f,0);
        newTrans.localScale = new Vector2(stackBounds,0.5f);

        lastBlock = newTrans;
        prevBlockPos = newTrans.position;
        stackCount++;
    }
    public void ShowUI()
    {
        Debug.Log("스택 미니 게임 설명");
    }
}