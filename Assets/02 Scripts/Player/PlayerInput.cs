using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool IsClicked { get; private set; } = false;
    //다른 인풋이 있을 시 추가
    //public bool IsSpacePressed { get; private set; } = false;
    void Update()
    {
        IsClicked = Input.GetMouseButtonDown(0);
        if (IsClicked) AudioManager.Instance.PlayJumpSFX(); //클릭시 사운드 추가(점프)
        //IsSpacePressed = Input.GetKeyDown(KeyCode.Space);
    }
}
