using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coin_counter : MonoBehaviour
{
    public int coin_amount = 0;
    public void Update_counter()
    {
        this.gameObject.GetComponent<Text>().text = "Coins: " + coin_amount;
    }
}
