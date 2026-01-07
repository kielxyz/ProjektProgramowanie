using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Sc_Finish_Level : MonoBehaviour
{
    private AudioSource finishLevelSFX;

    private bool levelCompleted = false;
    void Update()
    {
        finishLevelSFX = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            Debug.Log("Level Finished!");
            finishLevelSFX.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 1.3f);
        }
    }


    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
