using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTime;
    public float curTime;
    public Transform[] spawnPoints;
    public GameObject[] enemy;

    void Update()
    {
        if (curTime >= spawnTime)
        {
            int x = Random.Range(0, spawnPoints.Length);
            SpawnEnemy(x);

        }
        curTime += Time.deltaTime;  //타이머 역할
    }

    public void SpawnEnemy(int ranNum)
    {
        int spawnNum = Random.Range(0, 10);
        curTime = 0;
        if(spawnNum == 0)
        {
            Instantiate(enemy[3], spawnPoints[ranNum]);
        }
        if(spawnNum <= 2)
        {
            Instantiate(enemy[0], spawnPoints[ranNum]);
        } else if(spawnNum <= 5)
        {
            Instantiate(enemy[1], spawnPoints[ranNum]);
        } else
        {
            Instantiate(enemy[2], spawnPoints[ranNum]);
        }
    }
}
