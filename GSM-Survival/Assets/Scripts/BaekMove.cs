using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaekMove : MonoBehaviour
{
    Animator anim;
    public GameObject attack;
    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * 0.1f);
            anim.SetBool("isMove", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector2.up * 0.1f);
            anim.SetBool("isMove", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector2.right * 0.1f);
            anim.SetBool("isMove", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * 0.1f);
            anim.SetBool("isMove", true);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        { 
            if(time >= 4)
            {
                Instantiate(attack, transform.position, transform.rotation);
                time = 0.0f;
            }
        }
        else
        {
            anim.SetBool("isMove", false);
        }
    }
}
