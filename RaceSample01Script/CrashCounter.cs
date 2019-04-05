using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashCounter : MonoBehaviour
{
    GameObject gameMaster;
    bool gameclear;

    void Start()
    {
        gameMaster = GameObject.Find("GameMaster");
        gameclear = false;
    }

    void Update()
    {
        if(!gameclear)
        {
            gameclear = GameMasterController.gameclear;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!gameclear)
        {
            gameMaster.SendMessage("GameOver");
            Debug.Log("Crush!!!");
        }
    }
}
