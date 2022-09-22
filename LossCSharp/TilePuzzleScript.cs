using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TilePuzzleScript : MonoBehaviour
{
    // Reference to the empty gameObject
    [SerializeField] private Transform emptySpace = null;
    // Reference to the camera being used
    private Camera cameraObject;

    // List of Tiles; Added through the Editor
    [SerializeField] private TileBehavior[] tilesList;

    // Hardcoded location of the empty space
    private int emptySpaceIndex = 15;

    // Start is called before the first frame update
    void Start()
    {
        // Calling upon specifed camera
        cameraObject = Camera.main;
        ShuffleTiles();
    }

    // Update is called once per frame
    void Update()
    {
        SolveTiles();
        // If the left mouse button goes down
        if (Input.GetMouseButtonDown(0))
        {
            // Location of the Raycast on an object
            Ray rayLocation = cameraObject.ScreenPointToRay(Input.mousePosition);
            // Value telling if object with raycast was pressed
            RaycastHit2D objectHit = Physics2D.Raycast(rayLocation.origin, rayLocation.direction);

            // If object with raycast was pressed
            if (objectHit)
            {
                // Debug.Log(objectHit.transform.name + " was hit.");
                // If the distance between the position of the empty space object and the hit object is less than 3
                if (Vector2.Distance(emptySpace.position, objectHit.transform.position) < 3)
                {
                    // Temp Value of Last Location of Empty Space Object
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    // Reference to TilesBehavior's Current Tile Target Location
                    TileBehavior currentTile = objectHit.transform.GetComponent<TileBehavior>();
                    // Moves Empty Space Object to Hit Object's Location
                    emptySpace.position = currentTile.targetPosition;
                    // Moves Hit Object to Empty Space's Former Location
                    currentTile.targetPosition = lastEmptySpacePosition;


                    // Finds index of current tile
                    int currentTileIndex = findIndex(currentTile);
                    // Sets empty space index to the index of the current tile
                    tilesList[emptySpaceIndex] = tilesList[currentTileIndex];
                    // Changes current tile to an empty space
                    tilesList[currentTileIndex] = null;
                    // Sets old empty index to the current tile index
                    emptySpaceIndex = currentTileIndex;
                }
            }
        }
    }

    // Shuffles location of tiles
    public void ShuffleTiles()
    {
        // Ensures empty space is at the bottom right of the grid before shuffling
        if (emptySpaceIndex != 15)
        {
            // Changes Tile Location in Game
            Vector3 tileAtEndOfList = tilesList[15].targetPosition;
            tilesList[15].targetPosition = emptySpace.position;
            emptySpace.position = tileAtEndOfList;

            // Changes Tile Location in List
            tilesList[emptySpaceIndex] = tilesList[15];
            tilesList[15] = null;
            emptySpaceIndex = 15;
        }
        int invertionValue;
        do
        {
            for (int i = 0; i <= tilesList.Length - 1; i++)
            {
                // As long as the current tile isn't the empty space
                if (tilesList[i] != null)
                {
                    // Previous Location of Tile at i Index
                    Vector3 lastPosition = tilesList[i].targetPosition;
                    // Random Value based on the list length, excluding the empty space
                    int randomValue = Random.Range(0, tilesList.Length - 1);
                    // Setting the target location of the indexed tile to a random location
                    tilesList[i].targetPosition = tilesList[randomValue].targetPosition;
                    // Swapping the tiles locations
                    tilesList[randomValue].targetPosition = lastPosition;


                    // Stores currently indexed tile
                    TileBehavior tile = tilesList[i];
                    // Changes currently indexed tile to randomly indexed tile
                    tilesList[i] = tilesList[randomValue];
                    // Changes randomly indexed tile to stored indexed tile 
                    tilesList[randomValue] = tile;
                }
            }
            invertionValue = GetInversion();
            Debug.Log("Its been shuffled.");
        } while (invertionValue % 2 != 0);
    }

    // Finds index of specified tileObject
    public int findIndex(TileBehavior tileObject)
    {
        for (int i = 0; i < tilesList.Length; i++)
        {
            // As long as the current tile isn't the empty space
            if (tilesList[i] != null)
            {
                // If indexed tile matches the specified tile
                if (tilesList[i] == tileObject)
                {
                    // Return the index of the indexed tile
                    return i;
                }
            }
        }
        // If nothing comes up, return -1
        return -1;
    }

    // Determines if puzzle is solvable
    // Compares assigned number value to see how many values are higher
    int GetInversion()
    {
        int inversionSum = 0;
        for (int i = 0; i < tilesList.Length; i++)
        {
            int thisTileInversion = 0;
            for (int j = i; j < tilesList.Length; j++)
            {
                if (tilesList[j] != null)
                {
                    if (tilesList[i].number > tilesList[j].number)
                    {
                        thisTileInversion++;
                    }
                }
            }
            inversionSum = thisTileInversion;
        }
        return inversionSum;
    }

    void SolveTiles(){
        if(FindObjectOfType<World>().slidingPuzzle){
            SceneManager.LoadScene("JanitorCloset");
        }
    }
}
