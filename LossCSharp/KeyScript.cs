using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    //Allow the Player to pick up a key
    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player") {
            //If the Key is Green
            if(this.tag == "Green"){
            Destroy(this.gameObject, 0.01f);
            //Set World Public Methods
            FindObjectOfType<World>().SetGreenKey();
            }
            //If the Key is Red
            if(this.tag == "Red"){
            Destroy(this.gameObject, 0.01f);
            //Set World Public  Methods
            FindObjectOfType<World>().SetRedKey();
            }
            //If the Key is Blue
            if(this.tag == "Blue"){
            Destroy(this.gameObject, 0.01f);
            //Set World Public  Methods
            FindObjectOfType<World>().SetBlueKey();
            }
            // TO DO: Gold Key
            if (this.tag == "Gold") {
            Destroy(this.gameObject, 0.01f);
            //Set World Public  Methods
            FindObjectOfType<World>().SetGoldKey();
            }
        }
    }
}
