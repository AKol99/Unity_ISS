using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartGameAfter = 5f;

    public void EndGame()
    {
        Debug.Log("GAME OVER");
        Invoke("RestartGame", restartGameAfter);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
