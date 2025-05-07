using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMiniGame
{
    void StartMiniGame();
    void ShowUI();
    void ShowOffUI();
}

public class MiniGameZoneController : MonoBehaviour
{
    private IMiniGame game;
    bool isUIActive = false;
    private void Start()
    {
        game = GetComponentInChildren<IMiniGame>();
    }
    private void Update()
    {
        if(isUIActive && Input.GetKeyDown(KeyCode.F))
        {
            game.StartMiniGame();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            game.ShowUI();
            isUIActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            game.ShowOffUI();
            isUIActive = false;
        }
    }
}
