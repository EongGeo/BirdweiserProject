using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool IsClicked { get; private set; } = false;
    //�ٸ� ��ǲ�� ���� �� �߰�
    //public bool IsSpacePressed { get; private set; } = false;
    void Update()
    {
        IsClicked = Input.GetMouseButtonDown(0);
        if (IsClicked) AudioManager.Instance.PlayJumpSFX(); //Ŭ���� ���� �߰�(����)
        //IsSpacePressed = Input.GetKeyDown(KeyCode.Space);
    }
}
