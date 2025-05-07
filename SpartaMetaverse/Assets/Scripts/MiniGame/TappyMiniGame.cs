using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TappyMiniGame : MonoBehaviour, IMiniGame
{
    [SerializeField] private GameObject canvas;
    public const string tappy = "TappyPlaneGame";
    public const string LastScore = "TappyLastScore";
    public Transform result;
    public TextMeshProUGUI lastScore;
    private void Start()
    {
        result = transform.Find("Result");
        if (GameState.Instance.fromMiniGame)
        {
            StartCoroutine(ActiveResult());
        }
    }

    public void StartMiniGame()
    {
        SceneManager.LoadScene(tappy);
    }

    public void ShowUI()
    {
        canvas.SetActive(true);
    }

    public void ShowOffUI()
    {
        canvas.SetActive(false);
    }
    IEnumerator ActiveResult()
    {
        lastScore.text = PlayerPrefs.GetInt(LastScore).ToString();
        result.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        result.gameObject.SetActive(false);
    }
}
