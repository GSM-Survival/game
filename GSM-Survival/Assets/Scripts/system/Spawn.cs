using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] charPrefabs;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = Instantiate(charPrefabs[(int)DataMgr.instance.currentCharacter]);
        player.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
