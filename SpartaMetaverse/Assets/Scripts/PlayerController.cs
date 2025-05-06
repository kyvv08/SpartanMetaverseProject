using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private Camera camera;

    private IMiniGame miniGame;

    private const string str_miniGameZone = "MinigameZone";

    bool isTrigger_mini = false;
    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    protected override void HandleAction()
    {
        if(isTrigger_mini && Input.GetKeyDown(KeyCode.F))
        {
            miniGame.StartMiniGame();
        }
    }

    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
        if (movementDirection != Vector2.zero)
        {
            lookDirection = movementDirection;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(str_miniGameZone))
        {
            miniGame = collision.GetComponent<IMiniGame>();
            isTrigger_mini = true;
            miniGame.ShowUI();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(str_miniGameZone))
        {
            isTrigger_mini = false;
            miniGame = null;
        }
    }
}