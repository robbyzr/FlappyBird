using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI yourScoreText;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        currentScoreText.text = score.ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        UpdateHighScore();

    }

    public void UpdateScore()
    {
        score += 1;
        currentScoreText.text = score.ToString();
        yourScoreText.text = score.ToString();
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = score.ToString();
        }
    }

    public void ZeroPoint()
    {
        score = 0;
        currentScoreText.text = score.ToString();
    }

   
}
