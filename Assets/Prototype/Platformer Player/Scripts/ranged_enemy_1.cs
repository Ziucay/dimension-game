using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ranged_enemy_1 : MonoBehaviour
{
    public float left_bound,right_bound;
    public bool dir = false;
    double timer = 3;
    public GameObject projectile;
    void Start()
    {
        timer = Random.Range(left_bound, right_bound);
        if (!dir)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else
        {
            timer = Random.Range(left_bound, right_bound);
            StartCoroutine("Shot");
        }
    }

    public IEnumerator Shot()
    {
        GetComponent<Animator>().SetBool("isAttack", true);
        yield return new WaitForSeconds(1);
        GameObject proj = Instantiate(projectile, new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y),Quaternion.identity);
        if (!dir)
        {
            proj.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300, 0), ForceMode2D.Force);
        }
        else
        {
            proj.GetComponent<SpriteRenderer>().flipX = true;
            proj.GetComponent<Rigidbody2D>().AddForce(new Vector2(300, 0), ForceMode2D.Force);
        }
        GetComponent<Animator>().SetBool("isAttack", false);
    }
}
