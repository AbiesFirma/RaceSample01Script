using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float movePower = 1.0f;
    [SerializeField] float stopPower = 1.0f;

    Vector3 startPos;
    Vector3 currentPos;

    bool onFlick = false;

    float horizontalDerJudge;
    float verticalDerJudge;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            onFlick = true;
        }
        if(Input.GetMouseButton(0))
        {
            currentPos = Input.mousePosition;
            horizontalDerJudge = currentPos.x - startPos.x;
            verticalDerJudge = currentPos.y - startPos.y;

            /*
            if(horizontalDerJudge > 0)
            {
                Debug.Log("right");
            }
            else if (horizontalDerJudge < 0)
            {
                Debug.Log("left");
            }
            else
            {
                Debug.Log("tap");
            }
            */
        }
        if (Input.GetMouseButtonUp(0))
        {
            onFlick = false;
        }

        if(!onFlick)
        {
            horizontalDerJudge = 0.0f;
            verticalDerJudge = 0.0f;
        }

    }

    void FixedUpdate()
    {        
        rb.AddForce(transform.right * (horizontalDerJudge * movePower * 0.1f) - (rb.velocity * stopPower));
        rb.AddForce(transform.forward * (verticalDerJudge * movePower * 0.1f) - (rb.velocity * stopPower * 0.6f));
    }

    
}
