using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //Bool for Pause Menu
    public bool menuUp = false;
    [SerializeField] GameObject PauseSlider;
    [SerializeField] GameObject quitButton;

    // Quit Game Function
    public void QuitGame() 
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    //Pause Game Function
    public void Pause()
    {
        //Set Bool
        menuUp = true;
        //Set Time scale
        Time.timeScale = 0;
        GameObject.FindWithTag("DiaryImage").GetComponent<Image>().enabled = true;
        GameObject.FindWithTag("PauseText").GetComponent<Text>().enabled = true;
        GameObject.FindWithTag("Barrier").GetComponent<Text>().enabled = true;
        PauseSlider.SetActive(true);
        quitButton.SetActive(true);
        //Pause Music
    }
    //Resume Game Function
    public void Resume()
    {
        //Set Time scale back to 1
        Time.timeScale = 1;
        //Reset Menu Bool
        menuUp = false;
        GameObject.FindWithTag("DiaryImage").GetComponent<Image>().enabled = false;
        GameObject.FindWithTag("PauseText").GetComponent<Text>().enabled = false;
        GameObject.FindWithTag("Barrier").GetComponent<Text>().enabled = false;
        PauseSlider.SetActive(false);
        quitButton.SetActive(false);
        //Play music
    }

    //Button Handler
    public void PauseButton(){
        if(!menuUp){
            Pause();
        }
        else if(menuUp){
            Resume();
        }
    }

    public void SkipButton(){
        if(SceneManager.GetActiveScene().name == "SetUp"){
            SceneManager.LoadScene("FirstRoom");
        }
        if(SceneManager.GetActiveScene().name == "WarMemento"){
            SceneManager.LoadScene("MementoRoom");
        }
        if(SceneManager.GetActiveScene().name == "FamineMemento"){
            SceneManager.LoadScene("ScienceRoom");
        }
        if(SceneManager.GetActiveScene().name == "ConquestMemento"){
            SceneManager.LoadScene("Credits");
        }
    }

}
