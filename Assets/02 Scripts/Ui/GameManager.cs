using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score = 0;

    public PlayerData playerData;
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            if (playerObj.TryGetComponent<PlayerData>(out PlayerData PD))
            {
                playerData = PD;
            }
            else
            {
                Debug.Log("스크립트가 없습니다.");
            }
        }
        else
        {
            Debug.Log("스크립트가 없습니다.");
        }
    }

    private void Update()
    {
        scoreText.text = $"Score: {playerData.Score}";
    }

    // 게임 끝날때 로직

    public Text finalScoreText;

    public void OnPlayerDied()
    {
        if (finalScoreText != null)
        {
            finalScoreText.text = "SCORE : " + score.ToString();
        }

        gameOverPanel.SetActive(true);
    }

    public void RestartGame() //restart
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
