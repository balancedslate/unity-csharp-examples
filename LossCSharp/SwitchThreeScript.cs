using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchThreeScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        GetComponentInChildren<Text>().text = "Press Enter";
    }
    //If the Player CLicks Enter in Switch Three
    void OnTriggerStay2D(Collider2D col){
        if(col.tag == "Player" && Input.GetKey(KeyCode.Return)){
            //If the Player has activated both Switches
            if(FindObjectOfType<World>().switchOne && FindObjectOfType<World>().switchTwo){
            //Call The public world function to solve the puzzle
            FindObjectOfType<World>().solveSwitchPuzzle();
            }
            //else, Clear all switch booleans
            else{
                FindObjectOfType<World>().clearAllSwitches();
                GetComponentInChildren<Text>().text = "Wrong Order. Try Again.";
            }
        }
    }
}
