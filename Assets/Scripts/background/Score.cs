using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public static float scoreValue = 0;
    
    public float highscore;

    public Text highscoretext;
    public Text scoretext;

    private void Awake()
    {
        scoreValue = 0;
    }
    void Start()
    {
        highscore = PlayerPrefs.GetFloat("HighScore");
    }

    
    void Update()
    {
        scoretext.text = "Score: " + scoreValue;
        highscoretext.text = "High Score: " + highscore.ToString();

        if(scoreValue > highscore)
        {
            PlayerPrefs.SetFloat("HighScore", scoreValue);
            highscore = PlayerPrefs.GetFloat("HighScore");
        }
       
    }
}
