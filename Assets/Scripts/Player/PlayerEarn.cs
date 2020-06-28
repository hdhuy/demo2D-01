using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEarn : Player
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("coin"))
        {
            int value = collision.GetComponent<CoinItem>().Value;
            int coin = PlayerPrefs.GetInt("coin");
            PlayerPrefs.SetInt("coin", coin+ value);
            UI.changeCoinText();
            Destroy(collision.gameObject);
        }
    }
}
