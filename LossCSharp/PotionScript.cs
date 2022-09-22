using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player") {
            Debug.Log("You have picked up the Potion");
            //Destroy Game Object
            Destroy(this.gameObject, 0.01f);
            //Set World public bool to true
            if(FindObjectOfType<World>().currentHealth < 30){
                FindObjectOfType<World>().HealthPotion();
                FindObjectOfType<PlayerScript>().potionPickup();
            }
        }
    }
}
