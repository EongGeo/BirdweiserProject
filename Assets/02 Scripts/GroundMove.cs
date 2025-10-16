using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    [Header("�����̵�")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float resetX = -6.14f;
    [SerializeField] private float startX = 6.14f;

    private bool isMoving = true;

    void Update()
    {
        if (!isMoving) return;

        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x <= resetX)
        {
            Vector2 pos = transform.position;
            pos.x = startX;
            transform.position = pos;
        }
    }
    public void PauseGroundMoving()
    {
        isMoving = false;
    }

}
