using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject startImage;
    private bool gameStarted = false;
    
    
    void Start()
    {
        Time.timeScale = 0f;
        startImage.SetActive(true);

    }

    
    void Update()
    {
        if (!gameStarted && Input.GetMouseButtonDown(0))
        {
            StartGame();
            AudioManager.Instance.PlayNormalBGM();
        }

    }
    void StartGame()
    {
        startImage.SetActive(false);

        Time.timeScale = 1f;
        gameStarted = true;
    }
}
