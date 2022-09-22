using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    // Start is called before the first frame update
    public float knifeSpeed;
    int time = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += knifeSpeed * Vector3.left;
        time++;
        Die();
    }
    public void Die()
    {
        if (time == 1250)
        {
            Destroy(gameObject);
        }
        
    }
}
