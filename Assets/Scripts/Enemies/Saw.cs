using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{

    public float speed = 2f;
    float di;
   
    [SerializeField]
    public float damage = 10f;
    public int maxHealth = 100;
    int currenHealth;

    public GameObject fire;

    private void Awake()
    {
        currenHealth = maxHealth;
        di = Random.Range(-1f, 1f);
        
        if (di >= 0.1f)
        {
            di = 1f;
            speed = -speed;
        }
        else if (di <= 0.1f)
        {
            di = -1f;
            
        }
        Vector2 scale = transform.localScale;
        scale.x = di;
        transform.localScale = scale;
        Debug.Log(di);
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    void Move()
    {
        
        Vector2 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }

    public void TakeDamage(int damage)
    {
        currenHealth -= damage;

        if (currenHealth <= 0)
        {
            Instantiate(fire, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "saw")
        {
            speed = -speed;
            Vector2 scale = transform.localScale;
            scale.x = -scale.x;
            transform.localScale = scale;
            Instantiate(fire, transform.position, Quaternion.identity);

        }
        if (collision.gameObject.tag == "left")
        {

            speed = -speed;
            Vector2 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;
            Debug.Log("Left");
        }
        if (collision.gameObject.tag == "right")
        {
            speed = -speed;
            Vector2 scale = transform.localScale;
            scale.x = 1f;
            transform.localScale = scale;
            Debug.Log("Left");
        }
        if (collision.gameObject.tag == "player")
        {

            HeartBar.heart -= damage;
            Destroy(gameObject, 0.2f);
        }
        if (collision.gameObject.tag == "diezone")
        {
            Destroy(gameObject);
        }
    }

}