using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryScript : MonoBehaviour
{
    //If the player picks up the diary
    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player") {
            Debug.Log("You have picked up the diary");
            //Destroy Game Object
            Destroy(this.gameObject, 0.01f);
            //Set World public bool to true
            FindObjectOfType<World>().hasDiary = true;
            FindObjectOfType<World>().playerSource.PlayOneShot(FindObjectOfType<World>().itemNoise);
            //TODO - Wire Cutter Item
            //TODO - Pan Flute Item
        }
    }
}
