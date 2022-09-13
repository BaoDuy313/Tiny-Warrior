using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;

    public AudioSource audioSource;
    public AudioClip audioAttack;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 50;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (!PlayerDie.playIsDead)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Attack();
                    nextAttackTime = Time.time + (1f / attackRate);

                    audioSource.PlayOneShot(audioAttack);
                }
            }
        }
    }

    void Attack()
    {
        // play an attack animation
        anim.SetTrigger("Attack");

        // detect ennemies in range of mark
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Saw>().TakeDamage(attackDamage);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
