using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRootAutoMoveController : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;

    //GameObject gameMaster;
    bool gameOverClear;
    

    void Start()
    {
        //gameMaster = GameObject.Find("GameMaster");
        gameOverClear = false;
    }

    void Update()
    {
        if (!gameOverClear)
        {
            gameOverClear = GameMasterController.gameclear;

            if (!gameOverClear)
            {
                gameOverClear = GameMasterController.gameover;
            }
        }
       
        AutoMove();
    }

    void AutoMove()
    {
        if (gameOverClear)
        {
            speed *= 0.9f;
        }

        transform.Translate(0, 0, 0.1f * speed);
    }
}
