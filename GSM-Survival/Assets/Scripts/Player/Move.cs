using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sr;
    float time = 0.0f;

    public GameObject attack;
    public float skillTime = 0.0f;
    public int hp = 0;
    public float speed = 0.0f;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetButton("Horizontal"))
        {
            sr.flipX = Input.GetAxisRaw("Horizontal") != -1;
            if (Input.GetAxis("Horizontal") > 0)
                transform.Translate(Vector2.right * speed);
            else transform.Translate(-Vector2.right * speed);
            anim.SetBool("isMove", true);
        }
        else if (Input.GetButton("Vertical"))
        {
            if (Input.GetAxis("Vertical") > 0)
                transform.Translate(Vector2.up * speed);
            else transform.Translate(-Vector2.up * speed);
            anim.SetBool("isMove", true);
        }
        else
        {
            anim.SetBool("isMove", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (time >= skillTime)
            {
                Instantiate(attack, transform.position, transform.rotation);
                time = 0.0f;
            }
        }
    }

    public void OnDamaged(int attack)
    {
        hp -= attack;

        if(hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameManeger gameManager = FindObjectOfType<GameManeger>();
        gameManager.EndGame();
        Destroy(gameObject);
    }
}
