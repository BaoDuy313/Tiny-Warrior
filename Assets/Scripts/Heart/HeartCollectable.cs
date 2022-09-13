using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HeartCollectable : MonoBehaviour
{
    
    public float HeartPoint = 10f;
    public float countdown = 5f;

    public GameObject audioGetPoint;
    public GameObject textScore;
    private void Awake()
    {
        
    }
    void Start()
    {
        Destroy(gameObject, countdown);
    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "player")
        {
            Instantiate(audioGetPoint, transform.position, Quaternion.identity);

            Instantiate(textScore, transform.position, Quaternion.identity);

            Score.scoreValue += 10;

            if(HeartBar.heartBurn < 5)
            {
                HeartBar.heartBurn += 1;
            }

            HeartBar.heart += HeartPoint;
            // thoi gian Heart tu Destroy
            if (countdown >= 2f)
            {
                countdown -= 1f;
            }
            
            if (HeartBar.heart > 100)
            {
                HeartBar.heart = 100;
            }
            Destroy(gameObject);
        }
    }


}
