using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerMovement player;
    public WallSpawner wallSpawner;

    public GameObject mainMenuPanel;
    public GameObject gameOverPanel;
    
    private Score score;

    private AudioSource audioSource;
    public SfxScriptableObject sfx;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Score>();
        audioSource = GetComponent<AudioSource>();
        Pause();
    }


    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        audioSource.PlayOneShot(sfx.gameOverSfx);
        Pause();
    }

    public void RestartGame()
    {
        score.ZeroPoint();
        gameOverPanel.SetActive(false);
        player.StartPos();
        wallSpawner.DestroyWall();
        audioSource.PlayOneShot(sfx.clickSfx);
        Play();

    }

   

    public void PlayGame()
    {
        mainMenuPanel.SetActive(false);
        audioSource.PlayOneShot(sfx.clickSfx);
        Play();
    }

    public void Scoring()
    {
        audioSource.PlayOneShot(sfx.pointSfx);
    }


    public void MainMenu()
    {
        gameOverPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        player.StartPos();
        wallSpawner.DestroyWall();
        score.ZeroPoint();
        Pause();
    }

    public void Play()
    {
        Time.timeScale = 1f;

    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        audioSource.PlayOneShot(sfx.clickSfx);
        Application.Quit();
    }
}
