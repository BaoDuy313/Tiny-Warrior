using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHeart : MonoBehaviour
{
    public float CountDown = 0f;

    [SerializeField]
    private GameObject heart;

    void Start()
    {
        StartCoroutine(CreateHeart());
    }

    IEnumerator CreateHeart()
    {
        yield return new WaitForSeconds(CountDown);

        Vector2 temp = transform.position;
        temp.x += Random.Range(-8, 8);

        Instantiate(heart, temp, this.transform.rotation);

        StartCoroutine(CreateHeart());
    }
}
