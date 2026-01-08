using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Sc_Player_Health : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private Camera cam;

    [SerializeField] private AudioSource deathSFX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Debug.Log("Player hit by Trap!");
            Die();
        }
        else if (collision.gameObject.CompareTag("FallOffBox"))
        {
            Debug.Log("Player fell off the map!");
            Die();
        }
    }


    private void Die()
    {
        Debug.Log("Player Died!");
        deathSFX.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
