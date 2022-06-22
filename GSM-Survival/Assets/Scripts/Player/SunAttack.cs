using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SunAttack : MonoBehaviour
{
    float time = 0.0f;
    GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = FindObject("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
        time += Time.deltaTime;
        if(enemy != null) transform.position = Vector2.MoveTowards(transform.position, enemy.transform.position, 0.1f);
        if (time >= 0.6)
        {
            Destroy(gameObject);
        }
    }

    private GameObject FindObject(string tag)
    {
        var objects = GameObject.FindGameObjectsWithTag(tag).ToList();

        var neareastObject = objects.OrderBy(obj => {
            return Vector2.Distance(transform.position, obj.transform.position);
        }).FirstOrDefault();

        return neareastObject;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            EnemyMove enemyMove = collision.transform.GetComponent<EnemyMove>();
            enemyMove.OnDameged(10, "ball");
            Destroy(gameObject);
        }
    }
}
