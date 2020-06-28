using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    protected static bool isMoving;
    protected static bool isFlying;
    protected static bool isTurnRight ;
    protected static bool isHaveTarget ;
    protected static UIManager UI;
    protected static bool isEndGame;
    private void Start()
    {
        isEndGame = false;
        isMoving = false;
        isFlying = false;
        isTurnRight = true;
        isHaveTarget = false;
    }
    private void Awake()
    {
        UI = GameObject.Find("UI").GetComponent<UIManager>();
    }
}
