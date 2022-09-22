using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarMementoScript : MonoBehaviour
{
    // Start is called before the first frame update
   void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player") {
            Debug.Log("You have picked up the Memento!");
            //Destroy Game Object
            Destroy(this.gameObject, 0.01f);
            FindObjectOfType<World>().currentHealth = FindObjectOfType<World>().playerHealth;
            FindObjectOfType<World>().hasWarMemento = true;
            //Set World public bool to true
            FindObjectOfType<World>().playerSource.clip = FindObjectOfType<World>().memory;
            FindObjectOfType<World>().playerSource.Play();

            SceneManager.LoadScene("WarMemento");
        }
    }
}
