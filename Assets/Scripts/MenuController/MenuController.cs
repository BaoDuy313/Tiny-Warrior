using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level");
        Debug.Log("Level...");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit...");
    }
}
