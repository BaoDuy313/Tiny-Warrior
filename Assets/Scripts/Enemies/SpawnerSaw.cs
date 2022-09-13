using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSaw : MonoBehaviour
{

    [SerializeField]
    private GameObject saw;
    
    public int count =5;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(CreatePlane());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CreatePlane()
    {
        yield return new WaitForSeconds(count);

        Vector2 temp = transform.position;
        temp.x += Random.Range(-8, 8);

        Instantiate(saw, temp, this.transform.rotation);

        StartCoroutine(CreatePlane());
    }
}