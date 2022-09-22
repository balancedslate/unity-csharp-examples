using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    // Where Tile Should Go
    public Vector3 targetPosition;
    private Vector3 correctPosition;

    public int number;

    // Start is called before the first frame update
    void Awake()
    {
        // Sets target position to the current location of the tiles in the first frame
        targetPosition = transform.position;
        // Stores correct answer position as original position of tiles in first frame 
        correctPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Moves an object smoothly to the next location
        // Lerp(CurrentPosition, TargetPosition, Distance Covered Per Frame)
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);
        //if (targetPosition == correctPosition)
        //{
        //    Debug.Log(transform.name + " in right location.");
        //}

        if (transform.name == "Tile (0)" && targetPosition == correctPosition)
        {
            Debug.Log(transform.name + " is in the right place.");
            FindObjectOfType<World>().slidingOne = true;
            
        }
        if (transform.name == "Tile (4)" && targetPosition == correctPosition)
        {
            Debug.Log(transform.name + " is in the right place.");
            FindObjectOfType<World>().slidingTwo = true;
        }
        if (transform.name == "Tile (5)" && targetPosition == correctPosition)
        {
            Debug.Log(transform.name + " is in the right place.");
            FindObjectOfType<World>().slidingThree = true;
        }
        if (transform.name == "Tile (9)" && targetPosition == correctPosition)
        {
            Debug.Log(transform.name + " is in the right place.");
            FindObjectOfType<World>().slidingFour = true;
        }
        if (transform.name == "Tile (10)" && (targetPosition == new Vector3(1.08f, -1.09f, 0) || targetPosition == new Vector3(3.28f, -1.09f, 0)))
        {
            Debug.Log(transform.name + " is in the right place.");
            FindObjectOfType<World>().slidingFive = true;
        }
        if (transform.name == "Tile (11)" && (targetPosition == new Vector3(1.08f, -1.09f, 0) || targetPosition == new Vector3(3.28f, -1.09f, 0)))
        {
            Debug.Log(transform.name + " is in the right place.");
            FindObjectOfType<World>().slidingSix = true;
        }

        //Set World Booleans to false
        if (transform.name == "Tile (0)" && targetPosition != correctPosition)
        {
            FindObjectOfType<World>().slidingOne = false;
        }
        if (transform.name == "Tile (4)" && targetPosition != correctPosition)
        {
            FindObjectOfType<World>().slidingTwo = false;
        }
        if (transform.name == "Tile (5)" && targetPosition != correctPosition)
        {
            FindObjectOfType<World>().slidingThree = false;
        }
        if (transform.name == "Tile (9)" && targetPosition != correctPosition)
        {
            FindObjectOfType<World>().slidingFour = false;
        }
        if (transform.name == "Tile (10)" && (targetPosition != new Vector3(1.08f, -1.09f, 0) && targetPosition != new Vector3(3.28f, -1.09f, 0)))
        {
            FindObjectOfType<World>().slidingFive = false;
        }
        if (transform.name == "Tile (11)" && (targetPosition != new Vector3(1.08f, -1.09f, 0) && targetPosition != new Vector3(3.28f, -1.09f, 0)))
        {
            FindObjectOfType<World>().slidingSix = false;
        }
    }
}
