using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaekAttack : MonoBehaviour
{
    float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.localScale += new Vector3(0.03f, 0.03f, 0.0f);
        if(time >= 0.4)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyMove enemyMove = collision.transform.GetComponent<EnemyMove>();
            enemyMove.OnDameged(20, "earthquake");
        }
    }
}
