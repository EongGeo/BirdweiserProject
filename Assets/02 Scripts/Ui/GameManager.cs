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
                Debug.Log("��ũ��Ʈ�� �����ϴ�.");
            }
        }
        else
        {
            Debug.Log("��ũ��Ʈ�� �����ϴ�.");
        }
    }

    private void Update()
    {
        scoreText.text = $"Score: {playerData.Score}";
    }

    // ���� ������ ����

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
