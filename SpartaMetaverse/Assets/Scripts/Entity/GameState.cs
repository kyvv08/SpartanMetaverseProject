using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance;
    public bool fromMiniGame = false;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}