using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; //싱글톤

    [Header("UI")]
    [SerializeField] private TMP_Text scoreText; //TextMeshPro에 연결
    

    private PlayerData playerData; 

    private void Awake()
    {   
        if (Instance == null) Instance = this;  //싱글톤 설정하고
        else Destroy(gameObject);
    }

    private void Start()
    {
        //씬에 있는 PlayData 가져오고
        PlayerController player = FindObjectOfType<PlayerController>(); 
        playerData = player.data;
       
        UpdateScoreText(); //처음에 0으로 시작
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