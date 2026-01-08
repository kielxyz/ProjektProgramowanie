using UnityEngine;
using UnityEngine.SceneManagement;

public class Sc_StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
