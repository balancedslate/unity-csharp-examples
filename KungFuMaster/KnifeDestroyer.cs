using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("knife"))
        {
            KnifeController ourKnife = other.GetComponent<KnifeController>();
            ourKnife.Die();
        }
    }
}
