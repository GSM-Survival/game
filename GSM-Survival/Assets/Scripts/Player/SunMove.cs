using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMove : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sr;
    public GameObject attack;
    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetButton("Horizontal"))
        {
            sr.flipX = Input.GetAxisRaw("Horizontal") != -1;
            if (Input.GetAxis("Horizontal") > 0)
                transform.Translate(Vector2.right * 0.1f);
            else transform.Translate(-Vector2.right * 0.1f);
            anim.SetBool("isMove", true);
        }
        else if (Input.GetButton("Vertical"))
        {
            if (Input.GetAxis("Vertical") > 0)
                transform.Translate(Vector2.up * 0.1f);
            else transform.Translate(-Vector2.up * 0.1f);
            anim.SetBool("isMove", true);
        }
        else
        {
            anim.SetBool("isMove", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (time >= 1)
            {
                Instantiate(attack, transform.position, transform.rotation);
                time = 0.0f;
            }
        }
    }
}
