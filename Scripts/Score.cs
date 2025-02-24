using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI yourScoreText;
    private int score;
    


    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       currentScoreText.text = score.ToString(); //menampilkan skor awal pada UI
       highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString(); //mengambil nilai High Score yang tersimpan di PlayerPrefs
       UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        //cek apakah skor saat ini lebih tinggi dari High Score yang tersimpan
        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);//menyimpan skor baru sebagai High Score di PlayerPrefs
            highScoreText.text = score.ToString();
        }
    }


    public void UpdateScore()
    {
        score += 1;
        currentScoreText.text = score.ToString();
        AudioManager.instance.GetPointSfx();
        yourScoreText.text = score.ToString();
        UpdateHighScore();
    }
}
