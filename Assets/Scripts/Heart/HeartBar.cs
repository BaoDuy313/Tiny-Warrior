using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeartBar : MonoBehaviour
{
    private Slider heartbar;
    private GameObject player;

    public static float heart;
    public static float heartBurn;

    private void Awake()
    {
        heartBurn = 1f;
        heart = 100f;
        player = GameObject.Find("player");
        heartbar = GameObject.Find("HeartBar").GetComponent<Slider>();

        heartbar.minValue = 0f;
        heartbar.maxValue = heart;

        heartbar.value = heart;

        PlayerDie.playIsDead = false;
    }
    [System.Obsolete]
    void Update()
    {
        if (!player) return;
        if (heart > 0)
        {
            heart -= heartBurn * Time.deltaTime;
            heartbar.value = heart;
        }
        else
        {
            heartbar.value = 0f;
            PlayerDie.playIsDead = true;
            Destroy(player,5f);
        }
    }
}
