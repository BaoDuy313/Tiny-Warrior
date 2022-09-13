using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    //public float heartPlayer;
    private Animator anim;
    public static bool playIsDead = false;


    void Awake()
    {
        playIsDead = false;
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        
    }

    void Update()
    {
        if (playIsDead)
        {
            anim.SetTrigger("Die");
        }
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "diezone")
        {
            playIsDead = true;
            Destroy(gameObject);
        }
    }

}
