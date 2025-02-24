using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOverPanel;

    [SerializeField] private GameObject tutorialText;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1f;
    }

    private void Start()
    {
        Invoke("DisableTutorialText", 3f);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        AudioManager.instance.GameOverSfx();
       
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
    }
    private void DisableTutorialText()
    {
        tutorialText.SetActive(false);
    }   
}
