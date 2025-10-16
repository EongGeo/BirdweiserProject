using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [Header("파이프 이동설정")]
    [SerializeField] private float moveSpeed = 3.0f; //파이프의 이동속도
    [SerializeField] private float screenOutX = -2f; // 화면 바깥의 x좌표


    void Update()
    {
        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < screenOutX)
        {
            gameObject.SetActive(false);
        }
    }
}