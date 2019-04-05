using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAutoMove : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    bool ready;
    //GameObject gameMaster;

    void Start()
    {
        //gameMaster = GameObject.Find("GameMaster");
        ready = true;
    }

    void Update()
    {
        if (ready == true)
        {
            ready = GameMasterController.ready;
        }
        else
        {
            transform.Translate(0, 0, speed);
        }
    }
}
