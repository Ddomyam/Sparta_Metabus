using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI quitText;

    int bestScore = 0;
    private const string BestScoreKey = "BestScore";


    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null)
            Debug.LogError("");

        if (restartText == null)
            Debug.LogError("");     
        
        if (quitText == null)
            Debug.LogError("");

        restartText.gameObject.SetActive(false);
        quitText.gameObject.SetActive(false);

        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        bestScoreText.text = bestScore.ToString();
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
        quitText.gameObject.SetActive(true);
    }


    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
        if (bestScore < score)
        {
            bestScore = score;
            bestScoreText.text = bestScore.ToString();
            PlayerPrefs.SetInt(BestScoreKey, bestScore);
        }
    }
}
