using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI returnText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI bestScore;

    public const string highScore = "tappyHighScore";

    // Start is called before the first frame update
    void Start()
    {
        if (returnText == null)
        {
            Debug.LogError("returnText is null");
        }
        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
        }
        returnText.gameObject.SetActive(false);
        bestScore.gameObject.SetActive(false);
        bestScoreText.gameObject.SetActive(false);
    }

    public void SetRestart(int score)
    {
        returnText.gameObject.SetActive(true);
        bestScore.gameObject.SetActive(true);
        bestScoreText.gameObject.SetActive(true);
        int highscore = PlayerPrefs.GetInt(highScore);
        PlayerPrefs.SetInt(TappyMiniGame.LastScore, score);
        if(highscore < score)
        {
            PlayerPrefs.SetInt(highScore, score);
            highscore = score;
        }
        bestScore.text = highscore.ToString();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
