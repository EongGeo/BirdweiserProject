using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; //�̱���

    [Header("UI")]
    [SerializeField] private TMP_Text scoreText; //TextMeshPro�� ����
    

    private PlayerData playerData; 

    private void Awake()
    {   
        if (Instance == null) Instance = this;  //�̱��� �����ϰ�
        else Destroy(gameObject);
    }

    private void Start()
    {
        //���� �ִ� PlayData ��������
        PlayerController player = FindObjectOfType<PlayerController>(); 
        playerData = player.data;
       
        UpdateScoreText(); //ó���� 0���� ����
    }

    private void Update()
    {
       UpdateScoreText();     
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + playerData.Score;
    }
    
}