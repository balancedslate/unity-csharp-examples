using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Boolean for Diary Menu
    bool diaryLoaded = false;
    [SerializeField] AudioClip PanFluteSound;
    [SerializeField] Image beaker;

    // Update is called once per frame
    void Update()
    {
        //Look for Key Activation
        GreenKey();
        RedKey();
        BlueKey();
        //Look for Diary Activation
        DiaryUI();
        //Look for Wire Cutter Activation
        Wirecutters();
        //Look for Pan Flute Activation
        PanFluteUI();
        //Look for Beaker Activation
        BeakerUI();
        BeakerColor();
        //Check for Hint Activation
        FirstHintUI();
        SecondHintUI();
        //Check for Memento Activation
        SetFamineMementoUI();
        SetWarMementoUI();
        SetConquetMementoUI();
        //Look for Knife Activation
        KnifeUI();
        GoldKeyUI();
    }
    
    //Green Key Handler
    void GreenKey(){
        //Check Public World Bool
        if(FindObjectOfType<World>().hasGreenKey){
            //Set UI Image to Green
            GameObject.FindWithTag("GreenKeyUI").GetComponent<Image>().color = new Color(0.104f, 0.32f, 0.11f, 0.71f);
        }
    }

    //Red Key Handler
    void RedKey(){
        //Check World Public Bool
        if(FindObjectOfType<World>().hasRedKey){
            //Set UI Image to Red
            GameObject.FindWithTag("RedKeyUI").GetComponent<Image>().color = new Color(0.41f, 0.08f, 0.08f, 0.71f);
        }
    }

    //Blue Key Handler
    void BlueKey(){
        if(FindObjectOfType<World>().hasBlueKey){
            //Set UI Image to Red
            GameObject.FindWithTag("BlueKeyUI").GetComponent<Image>().color = new Color(0.09f, 0.14f, 0.30f, 0.71f);
        }
    }

    //Diary Collected Handler
    void DiaryUI(){
        //Check World public bool
        if(FindObjectOfType<World>().hasDiary){
            //Set the button to interactable
            GameObject.FindWithTag("DiaryUI").GetComponent<Button>().interactable = true;
        }
    }

    void KnifeUI(){
        if(FindObjectOfType<World>().hasKnife){
            //Set the button to interactable
            GameObject.FindWithTag("KnifeUI").GetComponent<Image>().color = new Color(1,1,1, .74f);
        }
    }

    void GoldKeyUI(){
        if(FindObjectOfType<World>().hasGoldKey){
            GameObject.FindWithTag("GoldUI").GetComponent<Image>().color = new Color(0.89f, 0.67f, 0.02f, 0.71f);
        }
    }

    //Diary UI Pause
    void DiaryPause()
    {
        //Pause Time
        Time.timeScale = 0;
        //Set Loaded Bool
        diaryLoaded = true;
        //Enable Image and Text
        GameObject.FindWithTag("DiaryImage").GetComponent<Image>().enabled = true;
        GameObject.FindWithTag("DiaryText1").GetComponent<Text>().enabled = true;
        GameObject.FindWithTag("DiaryText2").GetComponent<Text>().enabled = true;
        //Pause Music?
        FindObjectOfType<World>().playerSource.Pause();
    }

    //Diary UI Resume
    void DiaryResume()
    {
        //Resume Time
        Time.timeScale = 1;
        //Reset Bool
        diaryLoaded = false;
        //Diable Image and Text
        GameObject.FindWithTag("DiaryImage").GetComponent<Image>().enabled = false;
        GameObject.FindWithTag("DiaryText1").GetComponent<Text>().enabled = false;
        GameObject.FindWithTag("DiaryText2").GetComponent<Text>().enabled = false;
        //Resume Music
        FindObjectOfType<World>().playerSource.Play();
    }

    //Diary Button UI Handler - Called on click
    public void DiaryButton(){
        if(!diaryLoaded){
            DiaryPause();
        }
        else if(diaryLoaded){
            DiaryResume();
        }
    }

    public void Wirecutters(){
        if(FindObjectOfType<World>().hasWireCutters){
            //Set UI Image to Red
            GameObject.FindWithTag("WirecuttersUI").GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.71f);
        }
    }

    void PanFluteUI(){
        //Check World public bool
        if(FindObjectOfType<World>().hasPanFlute){
            //Set the button to interactable
            GameObject.FindWithTag("PanFluteUI").GetComponent<Button>().interactable = true;
        }
    }
    public void PanFluteClick(){
        FindObjectOfType<World>().playerSource.PlayOneShot(PanFluteSound);
        FindObjectOfType<World>().isPlaying = true;
    }

    public void BeakerUI(){
        if(FindObjectOfType<World>().selectedHazard){
            beaker.enabled = true;
        }
        else{
            beaker.enabled = false;
        }

    }

    public void BeakerColor(){
        if(FindObjectOfType<World>().playerChoice == "RED"){
            beaker.color = new Color(0.45f, 0f, 0f, 1f);
        }
        if(FindObjectOfType<World>().playerChoice == "PURPLE"){
            beaker.color = new Color(0.45f, 0f, 0.45f, 1f);
        }
        if(FindObjectOfType<World>().playerChoice == "YELLOW"){
            beaker.color = new Color(0.45f, 0.45f, 0f, 1f);
        }
        if(FindObjectOfType<World>().playerChoice == "BLUE"){
            beaker.color = new Color(0.01f, 0f, 0.45f, 1f);
        }
        if(FindObjectOfType<World>().playerChoice == "GREEN"){
            beaker.color = new Color(0.08f, 0.45f, 0f, 1f);
        }
    }

    //Hint UI Update Script
    public void FirstHintUI(){
        if(FindObjectOfType<World>().hasHintOne){
        GameObject.FindWithTag("DiaryText1").GetComponent<Text>().text = "In the Land of the Slimes, Famine Persists.\n\nHazardous poison will <i>trigger</i> a reaction";
        GameObject.FindWithTag("DiaryText2").GetComponent<Text>().text = "The <i>strongest</i> and <i>weakest</i>, guide the <i>combination.</i>\n \nThe Centrifuge will <i>show</I> you. \n\nWho is Responsible?";   
        }
    }

    public void SecondHintUI(){
        if(FindObjectOfType<World>().hasHintTwo){
        GameObject.FindWithTag("DiaryText1").GetComponent<Text>().text = "In the Courtyard of the Dead, Water Leaks.\n\nBeautiful Melodies will <i>trigger</i> gold rain";
        GameObject.FindWithTag("DiaryText2").GetComponent<Text>().text = "The <i>Instrument</i> of <i>Destruction</i> will blaze your trail\n \n Who can play the melody?\n\nWho will bear Conquest?";   
        }
    }

    //MementoUI Set Color Scripts
    public void SetWarMementoUI(){
        if(FindObjectOfType<World>().hasWarMemento){
            GameObject.FindWithTag("WarUI").GetComponent<Image>().color = new Color(.74f, 0f, 0f, .63f);
        }
    }

    public void SetFamineMementoUI(){
        if(FindObjectOfType<World>().hasFamineMemento){
            GameObject.FindWithTag("FamineUI").GetComponent<Image>().color = new Color(.67f, .67f, .15f, .63f);
        }
    }

    public void SetConquetMementoUI(){
        if(FindObjectOfType<World>().hasConquestMemento){
            GameObject.FindWithTag("ConquestUI").GetComponent<Image>().color = new Color(.14f, .16f, .60f, .63f);
        } 
    }
    
}
