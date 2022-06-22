using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("initPlayer", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            Vector3 playerPos = player.transform.position;
            transform.position = new Vector3(playerPos.x, playerPos.y, transform.position.z);
        }
    }

    private void initPlayer()
    {
        player = GameObject.FindWithTag("Player");
    }
}
