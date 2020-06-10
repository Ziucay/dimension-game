using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    public Sprite opened_door;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Main Character" && col.gameObject.GetComponent<player>().has_key)
        {
                GetComponent<SpriteRenderer>().sprite = opened_door;
                int next_level_index = SceneManager.GetActiveScene().buildIndex + 1;
                if (next_level_index == 4)
                    SceneManager.LoadScene(0);
                else
                    SceneManager.LoadScene(next_level_index);
        }
    }
}
