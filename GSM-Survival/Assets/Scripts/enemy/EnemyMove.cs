using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    GameObject player;
    public int hp = 0;
    public int attack = 0;
    public float speed = 0.0f;

    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        Invoke("initPlayer", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null) transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);
    }

    private void initPlayer()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void OnDameged(int attack, string attackType)
    {

        hp -= attack;
        playerAudio.Play();
        if(attackType == "earthquake")
        {

        }
        if(hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Move player = collision.gameObject.GetComponent<Move>();
            player.OnDamaged(attack);
        }
    }
}
