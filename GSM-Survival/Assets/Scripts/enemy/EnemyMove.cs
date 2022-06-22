using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    GameObject player;
    public int hp = 50;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("initPlayer", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null) transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 0.03f);
    }

    private void initPlayer()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void OnDameged(int attack, string attackType)
    {
        hp -= attack;
        if(attackType == "earthquake")
        {

        }
        if(hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
