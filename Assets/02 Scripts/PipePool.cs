using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipePool : MonoBehaviour
{
    [Header("파이프풀 설정")]
    [SerializeField] private GameObject upperPipePrefab; //위파이프
    [SerializeField] private GameObject lowerPipePrefab; //아래파이프
    [SerializeField] private int poolSize = 3;           //파이프풀크기
    [SerializeField] private float spawnInterval = 1.5f; //스폰간격
    [SerializeField] private float pipeSpawnX = 5f;      //파이프소환x좌표
    [SerializeField] private float gapSize = 2f;         //틈새크기
    


    private Queue<GameObject> upperPool = new Queue<GameObject>();       //파이프풀 큐로 생성
    private Queue<GameObject> lowerPool = new Queue<GameObject>();

    private bool isSpawning = true;

    void Start()
    {

        for (int i = 0; i < poolSize; i++)
        {


            GameObject upper = Instantiate(upperPipePrefab);
            upper.SetActive(false);
            upperPool.Enqueue(upper);

            GameObject lower = Instantiate(lowerPipePrefab);
            lower.SetActive(false);
            lowerPool.Enqueue(lower);
        }
        InvokeRepeating("SpawnPipe", 1f, spawnInterval); //InvokeRepeating(메서드명, 첫호출지연시간, 반복호출간격)
    }

    void SpawnPipe()
    {
        if (!isSpawning)
        {
            return;
        }
        float minY = 5.12f - 5.4f - gapSize / 2f;   //틈새크기의 중앙y최소좌표값은 맵절반크기 - 파이프길이 - 틈새크기절반
        float maxY = -5.12f +2.24f+ 5.4f + gapSize / 2f; //2.24는 ground스프라이트 길이
        float gapY = Random.Range(minY, maxY);   //gapY = 틈새크기의 중앙y좌표값범위


        GameObject upperPipe = upperPool.Dequeue();
        Vector2 upperPos = new Vector2(pipeSpawnX, gapY + gapSize / 2f + 5.4f / 2f); //파이프y좌표 = gapY + 틈새크기절반 + 파이프길이절반(파이프의 중앙에 y좌표값이 들어가기에)
        upperPipe.transform.position = upperPos;
        upperPipe.SetActive(true);

        GameObject lowerPipe = lowerPool.Dequeue();
        Vector2 lowerPos = new Vector2(pipeSpawnX, gapY - gapSize / 2f - 5.4f / 2f);
        lowerPipe.transform.position = lowerPos;
        lowerPipe.SetActive(true);

        upperPool.Enqueue(upperPipe);
        lowerPool.Enqueue(lowerPipe);

    }

    
    public void PauseAllPipes()
    {
        isSpawning = false;
        CancelInvoke(nameof(SpawnPipe));

        foreach (var pipe in upperPool)
        {
            if (pipe.activeInHierarchy)
            {
                var mover = pipe.GetComponent<Pipe>();
                if(mover != null) mover.enabled = false; //enabled = MonoBehavior 컴포넌트의 활성화 상태
            }
        }
        foreach (var pipe in lowerPool)
        {
            if (pipe.activeInHierarchy)
            {
                var mover = pipe.GetComponent<Pipe>();
                if (mover != null) mover.enabled = false;
            }
        }
    }
}