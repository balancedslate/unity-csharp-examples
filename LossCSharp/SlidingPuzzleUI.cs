using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlidingPuzzleUI : MonoBehaviour
{
    // Start is called before the first frame update
    public void onPauseClicked(){
        SceneManager.LoadScene("JanitorCloset");
    }
}
