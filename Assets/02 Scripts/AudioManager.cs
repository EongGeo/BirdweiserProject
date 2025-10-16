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

    public void PlayJumpSFX() //����
    {
        sfxSource.PlayOneShot(jumpSFX);
    }

    public void PlayScoreSFX() //���� ȹ��
    {
        sfxSource.PlayOneShot(scoreSFX);
    }
    public void PlayHitSFX() //�浹(����)
    {
        sfxSource.PlayOneShot(hitSFX);
    }

    public void PlayNormalBGM() //����
    {
        bgmSource.clip = normalBGM;
        bgmSource.loop = true;
        bgmSource.Play();
    }
    public void PlayGameOverBGM() //���ӿ�����
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
