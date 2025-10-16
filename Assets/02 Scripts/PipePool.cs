using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipePool : MonoBehaviour
{
    [Header("������Ǯ ����")]
    [SerializeField] private GameObject upperPipePrefab; //��������
    [SerializeField] private GameObject lowerPipePrefab; //�Ʒ�������
    [SerializeField] private int poolSize = 3;           //������Ǯũ��
    [SerializeField] private float spawnInterval = 1.5f; //��������
    [SerializeField] private float pipeSpawnX = 5f;      //��������ȯx��ǥ
    [SerializeField] private float gapSize = 2f;         //ƴ��ũ��
    


    private Queue<GameObject> upperPool = new Queue<GameObject>();       //������Ǯ ť�� ����
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
        InvokeRepeating("SpawnPipe", 1f, spawnInterval); //InvokeRepeating(�޼����, ùȣ�������ð�, �ݺ�ȣ�Ⱓ��)
    }

    void SpawnPipe()
    {
        if (!isSpawning)
        {
            return;
        }
        float minY = 5.12f - 5.4f - gapSize / 2f;   //ƴ��ũ���� �߾�y�ּ���ǥ���� ������ũ�� - ���������� - ƴ��ũ������
        float maxY = -5.12f +2.24f+ 5.4f + gapSize / 2f; //2.24�� ground��������Ʈ ����
        float gapY = Random.Range(minY, maxY);   //gapY = ƴ��ũ���� �߾�y��ǥ������


        GameObject upperPipe = upperPool.Dequeue();
        Vector2 upperPos = new Vector2(pipeSpawnX, gapY + gapSize / 2f + 5.4f / 2f); //������y��ǥ = gapY + ƴ��ũ������ + ��������������(�������� �߾ӿ� y��ǥ���� ���⿡)
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
                if(mover != null) mover.enabled = false; //enabled = MonoBehavior ������Ʈ�� Ȱ��ȭ ����
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