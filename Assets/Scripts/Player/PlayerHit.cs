using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private Animator anim;

    public GameObject blood;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "saw")
        {
            anim.SetTrigger("Hit");
            Instantiate(blood, transform.position, Quaternion.identity);
        }
        
    }
}
