using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] private int value = 1;
    [SerializeField] private AudioSource sfx;

    private void Awake()
    {
        var col = GetComponent<Collider2D>();
        if (col != null) col.isTrigger = true;
    }

    public int Collect(GameObject collector)
    {
        if (sfx != null)
        {
            sfx.Play();
            Destroy(gameObject, sfx.clip != null ? sfx.clip.length : 0f); // dziêki temu dŸwiêk siê odtworzy przed zniszczeniem obiektu
        }
        else
        {
            Destroy(gameObject);
        }
        return value;
    }
}