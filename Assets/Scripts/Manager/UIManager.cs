using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI restartText;

    int bestScore = 0;
    private const string BestScoreKey = "BestScore";


    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null)
            Debug.LogError("");

        if (restartText == null)
            Debug.LogError("");

        restartText.gameObject.SetActive(false);
//#if UNITY_EDITOR
//        // 유니티 에디터에서만 초기화
//        PlayerPrefs.DeleteKey(BestScoreKey);
//#endif
        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        bestScoreText.text = bestScore.ToString();
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
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
