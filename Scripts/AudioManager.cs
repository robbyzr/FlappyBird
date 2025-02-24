using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    private AudioSource audioSource;

    public AudioClip gameOverSfx;
    public AudioClip pointSfx;

    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        audioSource = GetComponent<AudioSource>();
    }

    //untuk menjalankan Sfx GameOver
   public void GameOverSfx()
   {
        audioSource.PlayOneShot(gameOverSfx);
   }
   //untuk menjalankan Sfx GameOver
   public void GetPointSfx()
   {
        audioSource.PlayOneShot(pointSfx);
   }
}
