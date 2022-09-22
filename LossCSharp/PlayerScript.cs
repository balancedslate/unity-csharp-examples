using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    //Movement Variables
    [SerializeField] float speed = 3.0f;
    [SerializeField] float jumpSpeed = .01f;
    [SerializeField] float knockbackSpeed = 4f;
    //Rigid bodies and player colliders
    Animator playerAnim;
    Rigidbody2D playerBody;
    public CircleCollider2D myFeetCollider;
    // Music for all levels
    [SerializeField] AudioClip wrongSound;
    [SerializeField] AudioClip gameSong;
    [SerializeField] AudioClip courtyard;
    [SerializeField] AudioClip memento;
    [SerializeField] AudioClip stationary;
    [SerializeField] AudioClip candySong;
    [SerializeField] AudioClip knifeThrow;
    //Public HealthBar
    [SerializeField] HealthBar healthbar;
    
    [SerializeField] GameObject Knife;
    public bool canthrow = true;

    //False = Right, True = Left
    public bool direction = false;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize variables on player
        playerAnim = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();
        myFeetCollider = GetComponentInChildren<CircleCollider2D>();
        healthbar.setHealth(FindObjectOfType<World>().currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //Walking:
        Walk();
        //Quit
        EscapeClicked();
        //Jump
        Jump();
        //On death
        Die();
        Attack();
        ThrowKnife();
        DemoCheats();
    }
     
    void DemoCheats(){
        if(Input.GetKeyDown(KeyCode.Insert)){
            FindObjectOfType<World>().setWireCutters();
            FindObjectOfType<World>().hasKnife = true;
            FindObjectOfType<World>().hasFamineMemento = true;
            FindObjectOfType<World>().hasDiary = true;
        }
    }
    

    //On Player Stay
    void OnTriggerStay2D(Collider2D col){
        //Check for scene change
        changeScene(col);
    }

    void HideEnterUI(Collider2D col){
        if(col.TryGetComponent(out EnterTextScript enter)){
            if(FindObjectOfType<MainMenu>().menuUp){
                enter.GetComponentInChildren<Canvas>().enabled = false;
            }
        }
    }


    void Walk() {
        //Right Walk
        if (Input.GetKey(KeyCode.D)) {
            playerAnim.SetBool("IsRightWalking", true);
            transform.position += speed * Vector3.right * Time.deltaTime;
            direction = false;
        }

        //Not Walking
        if(Input.GetKeyUp(KeyCode.D)) {
            playerAnim.SetBool("IsRightWalking", false);
            FindObjectOfType<World>().isPlaying = false;
        }

        //Left Walk
        if (Input.GetKey(KeyCode.A)) {
            playerAnim.SetBool("IsLeftWalking", true);
            transform.position += speed * Vector3.left * Time.deltaTime;
            direction = true;
        }
        //Not Walking
        if(Input.GetKeyUp(KeyCode.A)) {
            playerAnim.SetBool("IsLeftWalking", false);
            FindObjectOfType<World>().isPlaying = false;
        }
        //Check for other functions
       Jump(); 
       Attack();
       ThrowKnife();
    }

    void Attack(){
        if(Input.GetKeyDown(KeyCode.Backspace)){
            if(direction){
                playerAnim.SetBool("IsLeftAttacking", true);
                FindObjectOfType<World>().playerSource.PlayOneShot(knifeThrow);
            }
            if(!direction){
                playerAnim.SetBool("IsAttacking", true);
                FindObjectOfType<World>().playerSource.PlayOneShot(knifeThrow);
            }
            Debug.Log("You've Attacked");
        }
        if(Input.GetKeyUp(KeyCode.Backspace)){
            if(direction){
                playerAnim.SetBool("IsLeftAttacking", false);
            }
            if(!direction){
                playerAnim.SetBool("IsAttacking", false);
            }
        }
        ThrowKnife();
    }

    void ThrowKnife(){
        if(FindObjectOfType<World>().hasKnife){
            if(Input.GetKeyDown(KeyCode.P) && canthrow){
            Instantiate(Knife, this.transform.position, Quaternion.identity);
            FindObjectOfType<World>().playerSource.PlayOneShot(knifeThrow);
            }
        }
    }
    

    //Change Scene
    void changeScene(Collider2D col){
        //War Memento Scene Change
        if(Input.GetKey(KeyCode.Return) && col.tag == "MementoRoom"){
            if(FindObjectOfType<World>().hasRedKey) {
            //Set Spawn
            FindObjectOfType<World>().spawnLocation = "LEFT";
            //Set Music
            FindObjectOfType<World>().playerSource.clip = memento;
            FindObjectOfType<World>().playerSource.Play();
            //Load Scene
            SceneManager.LoadScene("MementoRoom");
            }
            else{
                //Play wrong sound
                FindObjectOfType<World>().playerSource.PlayOneShot(wrongSound);
                col.GetComponentInChildren<Text>().text = "You need the Red Key.";
            }   
        }

        //Coutyard Scene Change
        if (col.tag == "FirstRoom"){
            FindObjectOfType<World>().playerSource.clip = courtyard;
            FindObjectOfType<World>().playerSource.Play();
            FindObjectOfType<World>().janitor = "SWITCH";
            SceneManager.LoadScene("FirstRoom");
        }

        //Stationary Scene Change
        if(Input.GetKey(KeyCode.Return) && col.tag == "Stationary"){
            //Set Spawn
            FindObjectOfType<World>().spawnLocation = "LEFT";
            //Load Music
            FindObjectOfType<World>().playerSource.clip = stationary;
            FindObjectOfType<World>().playerSource.Play();
            //Load Scene
            SceneManager.LoadScene("StationaryRoom");
        }

        //Games Scene Change
        if(Input.GetKey(KeyCode.Return) && col.tag == "Games"){
            if(FindObjectOfType<World>().hasGreenKey){
            //Set Spawn
            FindObjectOfType<World>().spawnLocation = "RIGHT";
            //Set Song
            FindObjectOfType<World>().playerSource.clip = gameSong;
            FindObjectOfType<World>().playerSource.Play();
            //Load Scene
            SceneManager.LoadScene("GamesRoom");
            }
            else{
                //Play wrong sound
                FindObjectOfType<World>().playerSource.PlayOneShot(wrongSound);
                col.GetComponentInChildren<Text>().text = "You need the Green Key.";
            }
        }
        // Janitors Closet
        if(Input.GetKey(KeyCode.Return) && col.tag == "Janitors"){
            if(FindObjectOfType<World>().hasWireCutters){
                //Set Spawn
                FindObjectOfType<World>().spawnLocation = "JANITORS";
                //Set Music
                FindObjectOfType<World>().playerSource.clip = gameSong;
                FindObjectOfType<World>().playerSource.Play();
                //LoadScene
                SceneManager.LoadScene("JanitorCloset");
            }
            else{
                FindObjectOfType<World>().playerSource.PlayOneShot(wrongSound);
                col.GetComponentInChildren<Text>().text = "You need the Wire Cutters.";
            }
        }
        //Tile Puzzle
        if(Input.GetKey(KeyCode.Return) && col.tag == "TilePuzzle"){
            FindObjectOfType<World>().janitor = "SWITCH";
            SceneManager.LoadScene("SlidingPuzzleScreen");
        }
        // Science Room
        if(Input.GetKey(KeyCode.Return) && col.tag == "Science"){
            //Set Spawn
            FindObjectOfType<World>().janitor = "SCIENCE";
            //LoadScene
            SceneManager.LoadScene("ScienceRoom");
        }
        // Candy Shop
        if(Input.GetKey(KeyCode.Return) && col.tag == "Candy"){
            if(FindObjectOfType<World>().hasWireCutters){
                //Set Spawn
                FindObjectOfType<World>().spawnLocation = "CANDY";
                //Set Music
                FindObjectOfType<World>().playerSource.clip = candySong;
                FindObjectOfType<World>().playerSource.Play();
                //LoadScene
                SceneManager.LoadScene("CandyShop");
            }
            else{
                FindObjectOfType<World>().playerSource.PlayOneShot(wrongSound);
                col.GetComponentInChildren<Text>().text = "You need the Wire Cutters.";
            }
        }
        //Hat Shop
        if(Input.GetKey(KeyCode.Return) && col.tag == "Hat"){
            if(FindObjectOfType<World>().hasWireCutters){
                if(FindObjectOfType<World>().hasBlueKey){
                    //Set Spawn
                    FindObjectOfType<World>().spawnLocation = "HATSHOP";
                    //Set Music
                    FindObjectOfType<World>().playerSource.clip = candySong;
                    FindObjectOfType<World>().playerSource.Play();
                    //LoadScene
                    SceneManager.LoadScene("HatShop");
                }
                else{
                    FindObjectOfType<World>().playerSource.PlayOneShot(wrongSound);
                    col.GetComponentInChildren<Text>().text = "You need the Blue Key.";
                }
            }
            else{
                FindObjectOfType<World>().playerSource.PlayOneShot(wrongSound);
                col.GetComponentInChildren<Text>().text = "You need the Wire Cutters.";
            }
        }
        // Conquest Room
        if(Input.GetKey(KeyCode.Return) && col.tag == "Conquest"){
            if(FindObjectOfType<World>().hasFamineMemento){
                if(FindObjectOfType<World>().hasGoldKey){
                //Set Spawn
                FindObjectOfType<World>().spawnLocation = "RIGHT";
                //Set Song
                FindObjectOfType<World>().playerSource.clip = memento;
                FindObjectOfType<World>().playerSource.Play();
                //Load Scene
                SceneManager.LoadScene("ConquestRoom");
                }
                else{
                    //Play wrong sound
                    FindObjectOfType<World>().playerSource.PlayOneShot(wrongSound);
                    col.GetComponentInChildren<Text>().text = "You need the Gold Key.";
                }
            }
            else{
                col.GetComponentInChildren<Text>().text = "You need the Famine Memento.";
                FindObjectOfType<World>().playerSource.PlayOneShot(wrongSound);
            }
        }
        
        
    }

    //Quit Game Function
    void EscapeClicked(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            FindObjectOfType<MainMenu>().PauseButton();
        }
    }

    //Jump Function
    void Jump(){
        //Check for touching the ground
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { 
            return;
        }
        //Then add new vertical vector2
        if(Input.GetKeyDown(KeyCode.Space)){
            playerBody.velocity += new Vector2(0f, jumpSpeed);
        }
        ThrowKnife();
    }

    //Take damage
    public void playerHit(){
        FindObjectOfType<World>().TakeDamage();
        healthbar.setHealth(FindObjectOfType<World>().currentHealth);
    }

    public void potionPickup(){
        healthbar.setHealth(FindObjectOfType<World>().currentHealth);
    }
    
    //Check For enemy Hit
    public void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Enemy"){
            playerHit();
            playerBody.velocity += new Vector2(-playerBody.velocity.x + knockbackSpeed, knockbackSpeed);
        }
    }

    void Die(){
        if(FindObjectOfType<World>().currentHealth <= 0){
            FindObjectOfType<World>().onDeath();
            FindObjectOfType<World>().playerSource.clip = courtyard;
            FindObjectOfType<World>().playerSource.Play();
            SceneManager.LoadScene("DeathScene");
        }
    }

    
}
