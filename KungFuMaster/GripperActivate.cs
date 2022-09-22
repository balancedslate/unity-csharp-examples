using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripperActivate : MonoBehaviour
{
    // Start is called before the first frame update
    Animator gripperAnimator;
    void Start()
    {
        gripperAnimator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gripperAnimator.SetBool("InSearchRange", true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gripperAnimator.SetBool("InSearchRange", false);
        }
    }
    
}
