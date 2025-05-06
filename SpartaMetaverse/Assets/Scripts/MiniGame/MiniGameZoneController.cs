using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMiniGame
{
    void StartMiniGame();
    void ShowUI();
}

public class MiniGameZoneController : MonoBehaviour
{
    [SerializeField]
    private IMiniGame game;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            game.ShowUI();
        }
    }
}
