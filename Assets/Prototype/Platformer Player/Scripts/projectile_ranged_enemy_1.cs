using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_ranged_enemy_1 : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject);
    }
}
