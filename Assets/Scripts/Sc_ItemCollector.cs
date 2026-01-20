using UnityEngine;
using UnityEngine.UI;

public class Sc_ItemCollector : MonoBehaviour
{
    private int coins;
    [SerializeField] private Text CoinsText;
    [SerializeField] private AudioSource coinSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collectable = collision.GetComponent(typeof(ICollectable)) as ICollectable;
        if (collectable != null)
        {
            int v = collectable.Collect(gameObject);
            coins += v;
            if (coinSFX != null) coinSFX.Play();
            if (CoinsText != null) CoinsText.text = "Coins: " + coins;
        }
    }
}