using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Main Character")
        {
            col.GetComponent<player>().has_key = true;
            Destroy(this.gameObject);
        }
    }
}
