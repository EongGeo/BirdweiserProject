using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [Header("������ �̵�����")]
    [SerializeField] private float moveSpeed = 3.0f; //�������� �̵��ӵ�
    [SerializeField] private float screenOutX = -2f; // ȭ�� �ٱ��� x��ǥ


    void Update()
    {
        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < screenOutX)
        {
            gameObject.SetActive(false);
        }
    }
}