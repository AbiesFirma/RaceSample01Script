using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerController : MonoBehaviour
{
    [SerializeField] float timer = 10.0f;
    Text timeText;

    [SerializeField] GameObject gameMaster;
    bool ready;
    bool gameover;

    void Start()
    {
        timeText = GetComponent<Text>();

        if (gameMaster == null)
        {
            gameMaster = GameObject.Find("GameMaster");
        }

        ready = true;
        gameover = false;
    }

    void Update()
    {
        if (ready)
        {
            ready = GameMasterController.ready;
        }
        else
        {
            if (!gameover)
            {
                gameover = GameMasterController.gameover;
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    gameMaster.SendMessage("Clear");
                    timer = 0.0f;
                }
            }

            timeText.text = string.Format("{0:F2}", timer);
        }
    }
}
