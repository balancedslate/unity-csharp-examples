using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Initialize the Enemy Speed
    [SerializeField] float enemySpeed = 2f;

    //Tracking Function
    void OnTriggerStay2D(Collider2D col){
        if(col.tag == "Player"){
            transform.position = Vector2.MoveTowards(transform.position, col.GetComponent<Transform>().transform.position, enemySpeed * Time.deltaTime);
        }
    }

}
