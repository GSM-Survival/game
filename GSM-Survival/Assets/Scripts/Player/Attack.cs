using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Attack : MonoBehaviour
{
    float time = 0.0f;
    GameObject enemy;

    public int attack = 0;
    public float skillTime = 0.0f;
    public string attackType = "";
    // Start is called before the first frame update
    void Start()
    {
        enemy = FindObject("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(attackType == "ball" && enemy != null) transform.position = Vector2.MoveTowards(transform.position, enemy.transform.position, 0.1f);
        else if (attackType == "earthquake") transform.localScale += new Vector3(0.01f, 0.01f, 0.0f);
        if (time >= skillTime)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyMove enemyMove = collision.transform.GetComponent<EnemyMove>();
            enemyMove.OnDameged(attack, attackType);
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
}