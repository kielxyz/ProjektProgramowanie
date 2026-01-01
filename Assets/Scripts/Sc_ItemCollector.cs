using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Sc_ItemCollector : MonoBehaviour
{
    private int coins = 0;

    [SerializeField] private Text CoinsText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coins++;
            Destroy(collision.gameObject);
            Debug.Log("Coins: " + coins);
            CoinsText.text = "Coins: " + coins;
        }
    }
}
