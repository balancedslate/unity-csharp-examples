using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    
    Text ourText;
    PlayerController ourScript;
    GameObject scoreglobal;
    ScoreGlobal ourScore;
    // Start is called before the first frame update
    void Start()
    {
        ourText = GetComponent<Text>();
        ourScript = GetComponentInParent<PlayerController>();
        scoreglobal = GameObject.FindWithTag("s");
    }

    // Update is called once per frame
    void Update()
    {
        ourScore = scoreglobal.GetComponent<ScoreGlobal>();
        int score = ourScore.Score;
        ourText.text = "Score:" + score.ToString();
    }
}
