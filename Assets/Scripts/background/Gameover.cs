using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
  
    public GameObject GOMenuUI;
    private void Awake()
    {
        Resume();
    }
    void Update()
    {
        if (PlayerDie.playIsDead)
        {
            StartCoroutine(ExampleCoroutine());
        }
       
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(2);
        GO();
    }
    void GO()
    {
        GOMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        GOMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void RestartBTN()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game Play");
        PlayerDie.playIsDead = false;
    }
    public void QuitGameBTN()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
