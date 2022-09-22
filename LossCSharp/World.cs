using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    //This is a Global Scipt. It is a Singleton, and the First thing loaded when the Courtyard active.
    //This Script will handle all overworld functions, as it is never destroyed, and there is never two. 
    //In order to call this from other scripts, use: 
    // FindObjectOfType<World>()
    //if you follow that with a period, the methods or variables that are public will be avaiable from that script

    //Item and Key Public Booleans
    public bool hasRedKey = false;
    public bool hasGreenKey = false;
    public bool hasDiary = false;
    public bool hasHintOne = false;
    public bool hasHintTwo = false;
    public bool hasBlueKey = false;
    public bool hasGoldKey = false;
   
    public bool hasWireCutters = false;
    public bool hasPanFlute = false;
    public bool hasKnife = false;
    public bool hasCrown = false;

    public bool hasWarMemento = false;
    public bool hasFamineMemento = false;
    public bool hasConquestMemento = false;

    // FindObjectOfType<World>().playerSource.volume = GetCompenent<Slider>().value
    //Player Health
    public int playerHealth = 30;
    public int currentHealth;
    public bool healthLoaded = true;
    public int deathCount = 0;

    //Vending Machine Puzzle Booleans
    public bool switchOne = false;
    public bool switchTwo = false;
    public bool switchPuzzle = false;


    //Spawn Location String Handler, Only Set To ALL CAPS
    public string spawnLocation = "START";
    public string janitor = "SWITCH";
    //Global Audio Source
    public AudioSource playerSource;
    //Pre-Load Audio Clips
    [SerializeField] public AudioClip correctSound;
    [SerializeField] AudioClip wrongSound;
    [SerializeField] public AudioClip itemNoise;
    [SerializeField] public AudioClip memory;
    [SerializeField] public AudioClip credits;
    //Pre Load Green Key to Spawn when completed
    [SerializeField] GameObject greenKey;
    [SerializeField] GameObject goldKey;
    //TO-DO - PreLoad Memento Objects
    [SerializeField] GameObject warMemento;
    [SerializeField] GameObject famineMemento;
    //TO DO - Preload Gold Key for fountain


    //War Memento Puzzle Booleans
    public bool warMementoSwitchOne = false;
    public bool warMementoSwitchTwo = false;
    public bool warMementoSwitchThree = false;
    public bool warMementoSwitchFour = false;
    public bool warMementoSwitchFive = false;
    public bool warMementoSwitchSix = false;

    //Famine Memento Puzzle Variables
    public string playerChoice;
    public string choiceOne = "NONE";
    public string choiceTwo = "NONE";
    public bool selectedHazard = false;
    public bool firstchoice = true;
    public bool solvePuzzle = false;
    public bool isFailed = false;

    //Fountain Puzzle Boolean
    public bool isPlaying = false;
    public bool isFountain = false;

    //SLidng Puzzle Booleans
    public bool slidingOne = false;
    public bool slidingTwo = false;
    public bool slidingThree = false;
    public bool slidingFour = false;
    public bool slidingFive = false;
    public bool slidingSix = false;
    public bool slidingPuzzle = false;


    //Awake is the first function called by Unity
    void Awake(){
        //Singleton Function - Get the Array of World Objects
        int numberOfSessions = FindObjectsOfType<World>().Length;
        //If Greater than one,
        if (numberOfSessions > 1){
            //Destroy
            Destroy(gameObject);
        }
        else{
            //Else, Never Destroy.
            DontDestroyOnLoad(gameObject);
        }
    }

    //Initalize the World Audio Source
    void Start(){
        playerSource = GetComponent<AudioSource>();
        currentHealth = playerHealth;
    }
    void Update(){
        SolveFaminePuzzle();
        SolveFountain();
        SolveSlidingPuzzle();
    }
     
    //Key Functions - TODO - Remove Debug
    public void SetRedKey(){
         hasRedKey = true;
         playerSource.PlayOneShot(itemNoise);
         Debug.Log("You have picked up the red key");
    }
    public void SetGreenKey(){
         hasGreenKey = true;
         playerSource.PlayOneShot(itemNoise);
         Debug.Log("You have picked up the green key");
    }
    public void SetBlueKey(){
        hasBlueKey = true;
        playerSource.PlayOneShot(itemNoise);
        Debug.Log("You have picked up the Blue Key");
    }
    public void SetGoldKey()
    {
        hasGoldKey = true;
        playerSource.PlayOneShot(itemNoise);
        Debug.Log("You have picked up the Gold Key");
    }


    // Vending Puzzle Functions - TODO - Remove Debug
    public void setFirstSwitch(){
        if (!switchOne) {
        //Play Correct Sound
        playerSource.PlayOneShot(correctSound);
        //Set to true
        switchOne = true;
        Debug.Log("You have activated the first switch");
        }
    }
    public void setSecondSwitch(){
        if (!switchTwo) {
        //Play Correct Sound
        playerSource.PlayOneShot(correctSound);
        //Set to true
        switchTwo = true;
        Debug.Log("You have activated the second switch");
        }
    }
    public void clearAllSwitches(){
        //Play incorrect sound
        playerSource.PlayOneShot(wrongSound);
        //Set to false
        switchOne = false;
        switchTwo = false;
        Debug.Log("You have cleared all switches");
    }
    public void clearFirstSwitch() {
        //Play Incorrect sound
        playerSource.PlayOneShot(wrongSound);
        //Set false
        switchOne = false;
        Debug.Log("You have cleared the first switch");
    }
    public void solveSwitchPuzzle(){
        if(!switchPuzzle){
        playerSource.PlayOneShot(correctSound);
        switchPuzzle = true;
        Debug.Log("You have passed the puzzle");
        //Instatiate the preloaded green key
        Instantiate(greenKey, new Vector3(33.95f, -4.18f, 0), Quaternion.identity);
        }
    }

    //War Memento Puzzle Handler
    //Sets true and plays correct sound
    public void setFirstWarMementoSwitch(){
        if (!warMementoSwitchOne) {
        playerSource.PlayOneShot(correctSound);
        warMementoSwitchOne = true;
        Debug.Log("You have activated the first switch");
        }
    }
    public void setSecondWarMementoSwitch(){
        if (!warMementoSwitchTwo) {
        playerSource.PlayOneShot(correctSound);
        warMementoSwitchTwo = true;
        Debug.Log("You have activated the second switch");
        }
    }
    public void setThirdWarMementoSwitch(){
        if (!warMementoSwitchThree) {
        playerSource.PlayOneShot(correctSound);
        warMementoSwitchThree = true;
        Debug.Log("You have activated the third switch");
        }
    }
    public void setFourthWarMementoSwitch(){
        if (!warMementoSwitchFour) {
        playerSource.PlayOneShot(correctSound);
        warMementoSwitchFour = true;
        Debug.Log("You have activated the fourth switch");
        }
    }
    public void setFifthWarMementoSwitch(){
        if (!warMementoSwitchFive) {
        playerSource.PlayOneShot(correctSound);
        warMementoSwitchFive = true;
        Debug.Log("You have activated the fifth switch");
        }
    }
    public void setSixthWarMementoSwitch(){
        if (!warMementoSwitchSix) {
        playerSource.PlayOneShot(correctSound);
        warMementoSwitchSix = true;
        Debug.Log("You have activated the sixth switch");
        SolveWarMementoPuzzle();
        }
    }

    //Sets all switches to false
    public void clearWarMementoSwitches(){
        playerSource.PlayOneShot(wrongSound);
        warMementoSwitchOne = false;
        warMementoSwitchTwo = false;
        warMementoSwitchThree = false;
        warMementoSwitchFour = false;
        warMementoSwitchFive = false;
        warMementoSwitchSix = false;
        Debug.Log("You have cleared the switches.");
    }
    //Intiate War Memento Disk
    void SolveWarMementoPuzzle(){
        Debug.Log("You've Solved the puzzle");
        Instantiate(warMemento, new Vector3(3.55f, -.37f, 0), Quaternion.identity);
        //TODO - Instantiate Memento Item
    }
    
    //Sets to true
    public void setWireCutters(){
        hasWireCutters = true;
        playerSource.PlayOneShot(itemNoise);
    }

    //Sets to true
    public void setPanFlute(){
        hasPanFlute = true;
        playerSource.PlayOneShot(itemNoise);
    }

    //Pan Flute Script
    public void playPanFlute(AudioClip PanFlute){
        playerSource.PlayOneShot(PanFlute);
    }

    //Remove Health by One
    public void TakeDamage(){
        currentHealth -= 1;
        
    }
    //Add Health by One
    public void HealthPotion(){
        currentHealth += 1;
        playerSource.PlayOneShot(itemNoise);
    }

    public void setKnife(){
        hasKnife = true;
        playerSource.PlayOneShot(itemNoise);
    }


    //Famine Memento Functions
    //Sets the Color to the tag of the Collider
    public void SelectColor(string color){
        playerChoice = color;
        selectedHazard = true;
        isFailed = false;
        playerSource.PlayOneShot(correctSound);
    }

    //Places the first color onto the centrifuge
    public void placeFirstColor(){
        choiceOne = playerChoice;
        playerChoice = "NONE";
        selectedHazard = false;
    
    }
    //Places the second color on the centrifuge
    public void placeSecondColor(){
        choiceTwo = playerChoice;
        playerChoice = "NONE";
        selectedHazard = false;
    }

    //Handles the centrifuge functions
    public void placeColor(){
        if(firstchoice){
            placeFirstColor();
            firstchoice = false;
        }
        else if (!firstchoice && choiceTwo == "NONE"){
            placeSecondColor();
            solvePuzzle = true;
        }
    }

    //Checks if the puzzle has been solved
    void SolveFaminePuzzle(){
        if(solvePuzzle){
            solvePuzzle = false;
            if(choiceOne == "RED" || choiceTwo == "RED"){
                if(choiceOne == "BLUE" || choiceTwo == "BLUE"){
                    Debug.Log("You've solved the puzzle");
                    Instantiate(famineMemento, new Vector3(14.48f, -.13f, 0), Quaternion.identity);
                    playerSource.PlayOneShot(correctSound);
                    choiceOne = "";
                    choiceTwo = "";
                }
                else if(choiceOne != "NONE" && choiceTwo != "NONE"){
                    Debug.Log("You Failed.");
                    firstchoice = true;
                    choiceOne = "NONE";
                    choiceTwo = "NONE";
                    playerSource.PlayOneShot(wrongSound);
                    isFailed = true;
                }
            }
            else if(choiceOne != "NONE" && choiceTwo != "NONE"){
                Debug.Log("You Failed.");
                firstchoice = true;
                choiceOne = "NONE";
                choiceTwo = "NONE";
                playerSource.PlayOneShot(correctSound);
                isFailed = true;
            }
            
        }
    }

    //Solve Fountain Puzzle 
    public void SolveFountain(){
        if(isFountain){
            Instantiate(goldKey, new Vector3(7.58f, -2.0f, 0), Quaternion.identity);
            isPlaying = false;
        }
        isFountain = false;
    }

    //Solve Sliding Puzzle
    public void SolveSlidingPuzzle(){
        if(slidingOne && slidingTwo && slidingThree && slidingFour && slidingFive && slidingSix){
            slidingPuzzle = true;
            Debug.Log("You've Solved the Sliding Puzzle");
        }
    }


    //Set Hints
    public void setHintOne(){
        hasHintOne = true;
        playerSource.PlayOneShot(itemNoise);
    }
    public void setHintTwo() {
        hasHintTwo = true;
        playerSource.PlayOneShot(itemNoise);
    }




    public void onDeath(){
        //If Statements are established checkpoints
        if(hasGoldKey){
            currentHealth = playerHealth;
            spawnLocation = "START";
            Debug.Log("You Died");
        }
        else if(hasFamineMemento){
            hasGoldKey = false;
            slidingPuzzle = false;
            hasBlueKey = false;
            hasPanFlute = false;
            currentHealth = playerHealth;
            spawnLocation = "START";
            Debug.Log("You Died");
        }
        else if(hasWarMemento){
            hasGoldKey = false;
            slidingPuzzle = false;
            solvePuzzle = false;
            hasBlueKey = false;
            hasPanFlute = false;
            currentHealth = playerHealth;
            spawnLocation = "START";
            Debug.Log("You Died");
        }
        else if(hasRedKey){
            hasGoldKey = false;
            slidingPuzzle = false;
            solvePuzzle = false;
            warMementoSwitchOne = false;
            warMementoSwitchTwo = false;
            warMementoSwitchThree = false;
            warMementoSwitchFour = false;
            warMementoSwitchFive = false;
            warMementoSwitchSix = false;
            hasBlueKey = false;
            hasWireCutters = false;
            hasPanFlute = false;
            hasWarMemento = false;
            currentHealth = playerHealth;
            spawnLocation = "START";
            Debug.Log("You Died");
        }
        else if(hasDiary){
            hasGoldKey = false;
            slidingPuzzle = false;
            solvePuzzle = false;
            warMementoSwitchOne = false;
            warMementoSwitchTwo = false;
            warMementoSwitchThree = false;
            warMementoSwitchFour = false;
            warMementoSwitchFive = false;
            warMementoSwitchSix = false;
            switchOne = false;
            switchTwo = false;
            switchPuzzle = false;
            hasRedKey = false;
            hasGreenKey = false;
            hasBlueKey = false;
            hasWireCutters = false;
            hasPanFlute = false;
            hasWarMemento = false;
            currentHealth = playerHealth;
            spawnLocation = "START";
            Debug.Log("You Died");
        }
        else{
            hasGoldKey = false;
            slidingPuzzle = false;
            solvePuzzle = false;
            warMementoSwitchOne = false;
            warMementoSwitchTwo = false;
            warMementoSwitchThree = false;
            warMementoSwitchFour = false;
            warMementoSwitchFive = false;
            warMementoSwitchSix = false;
            switchOne = false;
            switchTwo = false;
            switchPuzzle = false;
            hasRedKey = false;
            hasGreenKey = false;
            hasDiary = false;
            hasBlueKey = false;
            hasWireCutters = false;
            hasPanFlute = false;
            hasWarMemento = false;
            currentHealth = playerHealth;
            spawnLocation = "START";
            Debug.Log("You Died");
        }
        deathCount++;
    }
    
    

  
}
