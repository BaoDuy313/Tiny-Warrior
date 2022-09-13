using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDie : MonoBehaviour
{
    public GameObject dieEffect;
    public int attackDamage = 60;

    void Start()
    {
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "player" && collision.gameObject.tag != "heart")
        {
            Die();
        }
        Saw saw = collision.GetComponent<Saw>();
        if(saw != null)
        {
            saw.TakeDamage(attackDamage);
            Die();
        }
       
    }
    void Die()
    {
        if (dieEffect != null)
        {
            Instantiate(dieEffect, transform.position, Quaternion.identity);
            
        }
        Destroy(gameObject);
    }
}
