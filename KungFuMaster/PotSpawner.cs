using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject snakePot;
    GameObject clone;
    int time;
    public Transform snakePos;
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time++;
        snakePos = this.transform;
        if (time % 500 == 0)
        {
            clone = Instantiate(snakePot, this.transform);
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
