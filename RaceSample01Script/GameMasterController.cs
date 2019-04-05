using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMasterController : MonoBehaviour
{
    [SerializeField] float startCountDownTimer = 4.0f;
    [SerializeField] Text countDownText;
    [SerializeField] GameObject gameStartTextObj;
    [SerializeField] GameObject gameOverTextObj;
    [SerializeField] GameObject gameClearTextObj;

    [SerializeField] GameObject tryagainUI;

    [SerializeField] GameObject playerRoot;

    static public bool ready { get; private set; }
    static public bool gameover;
    static public bool gameclear; 

    void Start()
    {
        ready = true;
        gameover = false;
        gameclear = false;
    }

    void Update()
    {
        if(ready)
        {
            startCountDownTimer -= Time.deltaTime;
            if (startCountDownTimer <= 3.0f)
            {
                int intTime = (int)startCountDownTimer;
                countDownText.text = string.Format("{0}", intTime);
            }            
            else
            {
                countDownText.text = string.Format("{0}", 3);
            }
        }

        if(startCountDownTimer < 1.0f && gameStartTextObj != null)
        {
            gameStartTextObj.SetActive(true);
            Destroy(gameStartTextObj, 1.0f);
        }

        if(startCountDownTimer <= 0)
        {
            ready = false;

            countDownText.enabled = false; ;
        }

        

    }

    void Clear()
    {
        Debug.Log("Clear");
        gameclear = true;
        gameClearTextObj.SetActive(true);
        tryagainUI.SetActive(true);
    }

    void GameOver()
    {
        gameover = true;
        gameOverTextObj.SetActive(true);
        tryagainUI.SetActive(true);
    }
}
