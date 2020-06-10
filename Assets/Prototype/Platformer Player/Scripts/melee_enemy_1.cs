using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee_enemy_1 : MonoBehaviour
{
    public double left_bound = 0;
    public double right_bound = 0;
    GameObject enemy;
    string dir = "left";
    void Start()
    {
        enemy = this.gameObject;
        left_bound = enemy.transform.position.x - Random.Range(.5f, 1.0f);
        right_bound = enemy.transform.position.x + Random.Range(.5f, 1.0f);
    }

    void Update()
    {
        if (dir == "left")
        {
            enemy.GetComponent<SpriteRenderer>().flipX = true;
            if (enemy.transform.position.x > left_bound)
                enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5, 0));
            else
                dir = "right";
        }
        else
        {
            enemy.GetComponent<SpriteRenderer>().flipX = false;
            if (enemy.transform.position.x < right_bound)
                enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(5, 0));
            else
                dir = "left";
        }
    }
}
