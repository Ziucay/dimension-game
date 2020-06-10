using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{

    public GameObject text;

    void Start()
    {
        text = GameObject.Find("coin_counter");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Main Character")
        {
            text.GetComponent<coin_counter>().coin_amount++;
            text.GetComponent<coin_counter>().Update_counter();
            Destroy(this.gameObject);
        }
    }
}
