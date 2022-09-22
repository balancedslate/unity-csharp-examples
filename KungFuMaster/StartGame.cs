using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject ourScript;
    ThomasGlobalHealth thomashealth;
    GameObject ourScore;
    ScoreGlobal score;
    
    public void OnStartClick()
    {
       GameObject Thomas = GameObject.Find("Thomas");

       bool animate = Thomas.GetComponent<StartThomasManager>().isAnimationFinished;

       Animator thomas = Thomas.GetComponent<Animator>();

       thomas.Play("StartAnimation");

      
       LoadLevel1();
    }

    void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }

    public void OnInstructionsClick()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void OnQuitButtonClick()
    {
        ourScript = GameObject.FindWithTag("health");
        thomashealth = ourScript.GetComponent<ThomasGlobalHealth>();
        ourScore = GameObject.FindWithTag("s");
        score = ourScore.GetComponent<ScoreGlobal>();
        score.Score = 1;
        thomashealth.playerHealth = 10;
        SceneManager.LoadScene("startScreen");

    }

}
