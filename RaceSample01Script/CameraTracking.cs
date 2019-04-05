using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] GameObject player;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("PlayerRoot");
        }
    }
        
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        this.transform.position = new Vector3(transform.position.x, transform.position.y, playerPos.z);
    }
}
