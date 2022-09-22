using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintScript : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player") {
            Debug.Log("You have picked up the Hint");
            //Destroy Game Object
            if(this.tag == "FirstHint"){
                FindObjectOfType<World>().setHintOne();
            }
            if(this.tag =="SecondHint"){
                FindObjectOfType<World>().setHintTwo();
            }
            Destroy(this.gameObject, 0.01f);
            
        }
    }
}
