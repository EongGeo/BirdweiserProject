using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header("BGM")]
    public AudioClip normalBGM;
    public AudioClip gameOverBGM;

    [Header("SFX")]
    public AudioClip jumpSFX;
    public AudioClip scoreSFX;
    public AudioClip hitSFX;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    public void PlayJumpSFX() //점프
    {
        sfxSource.PlayOneShot(jumpSFX);
    }

    public void PlayScoreSFX() //점수 획득
    {
        sfxSource.PlayOneShot(scoreSFX);
    }
    public void PlayHitSFX() //충돌(죽음)
    {
        sfxSource.PlayOneShot(hitSFX);
    }

    public void PlayNormalBGM() //평상시
    {
        bgmSource.clip = normalBGM;
        bgmSource.loop = true;
        bgmSource.Play();
    }
    public void PlayGameOverBGM() //게임오버시
    {
        bgmSource.clip = gameOverBGM;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }
}
