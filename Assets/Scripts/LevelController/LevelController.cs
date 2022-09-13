using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game Play");
        Debug.Log("Game Play...");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Menu...");
    }
}
