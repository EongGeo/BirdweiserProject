using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public bool IsDeath = false;
    public int Score { get; set; } = 0;

    public void AddScore()
    {
        Score++;
    }
    public void Reset()
    {
        Score = 0;
        IsDeath = false;
    }

}
