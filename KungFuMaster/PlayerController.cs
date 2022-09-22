using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    public bool isAirborne;
    public float speed;
    public float jump;
    public bool isPunching = false;
    public bool isKicking = false;
    GameObject scoreglobal;
    ScoreGlobal ourScore;
    GameObject GlobalHealth;
    ThomasGlobalHealth thomasHealth;

    // Start is called before the first frame update
    
    void Start()
    {
        animator = GetComponent<Animator>();
        scoreglobal = GameObject.FindWithTag("s");
        ourScore = scoreglobal.GetComponent<ScoreGlobal>();
        GlobalHealth = GameObject.FindWithTag("health");
        thomasHealth = GlobalHealth.GetComponent<ThomasGlobalHealth>();
    }
   
    // Update is called once per frame
    void Update()
    {
        Walk();
        Crouch();
        //Jump();
        Punch();
        Kick();
        onDie();
        OneLife();
    }
    
    ///Movement Animation------------------------------------------------------------------------
    void Walk()
        {
        
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += speed * Vector3.right;
                animator.SetBool("IsRightWalking", true);
                Punch();
                Kick();

            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                animator.SetBool("IsRightWalking", false);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += speed * Vector3.left;
                animator.SetBool("IsLeftWalking", true);
                Punch();
                Kick();
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                animator.SetBool("IsLeftWalking", false);
            }
        
        }
        void Crouch()
        {
            
            if (Input.GetKeyDown(KeyCode.DownArrow) && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                animator.SetBool("IsRightCrouching", true);
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                animator.SetBool("IsRightCrouching", false);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && animator.GetCurrentAnimatorStateInfo(0).IsName("ThomasLeftIdle"))
            {
                animator.SetBool("IsLeftCrouching", true);
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                animator.SetBool("IsLeftCrouching", false);
            }
            //Crouch Switch
            if (Input.GetKeyDown(KeyCode.LeftArrow) && animator.GetCurrentAnimatorStateInfo(0).IsName("ThomasRightCrouch"))
            {
                animator.SetBool("IsLeftCrouching", true);
                animator.SetBool("IsRightCrouching", false);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && animator.GetCurrentAnimatorStateInfo(0).IsName("ThomasLeftCrouch"))
            {
                animator.SetBool("IsRightCrouching", true);
                animator.SetBool("IsLeftCrouching", false);

            }
        }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 1);
            animator.SetBool("IsRightJumping", true);


        }
        if (isAirborne == true)
        {

            transform.position -= new Vector3(0, 1);
            animator.SetBool("IsRightJumping", false);

        }
    }
  
    

        //Attack Animation-----------------------------------------------------------------------------------------------------
        void Punch()
        {
            if (Input.GetKeyDown(KeyCode.A) && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                animator.SetTrigger("RightPunch");
                isKicking = false;
                isPunching = true;
                
            }
            if (Input.GetKeyDown(KeyCode.A) && animator.GetCurrentAnimatorStateInfo(0).IsName("ThomasLeftIdle"))
            {
                animator.SetTrigger("LeftPunch");
                isKicking = false;
                isPunching = true;
                
            }
            //Crouch Punches
            if (Input.GetKeyDown(KeyCode.A) && animator.GetCurrentAnimatorStateInfo(0).IsName("ThomasRightCrouch"))
            {
                animator.SetTrigger("RightCrouchPunch");
                isKicking = false;
                isPunching = true;
            }
            if (Input.GetKeyDown(KeyCode.A) && animator.GetCurrentAnimatorStateInfo(0).IsName("ThomasLeftCrouch"))
            {
                animator.SetTrigger("LeftCrouchPunch");
                isKicking = false;
                isPunching = true;
            }
        }
        void Kick()
        {
            if (Input.GetKeyDown(KeyCode.D) && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                animator.SetTrigger("RightKick");
                isPunching = false;
                isKicking = true;
                
            }
            if (Input.GetKeyDown(KeyCode.D) && animator.GetCurrentAnimatorStateInfo(0).IsName("ThomasLeftIdle"))
            {
                animator.SetTrigger("LeftKick");
                isPunching = false;
                isKicking = true;
            }
            //Crouch Kicks
            if (Input.GetKeyDown(KeyCode.D) && animator.GetCurrentAnimatorStateInfo(0).IsName("ThomasRightCrouch"))
            {
                animator.SetTrigger("RightCrouchKick");
                isPunching = false;
                isKicking = true;
            }
            if (Input.GetKeyDown(KeyCode.D) && animator.GetCurrentAnimatorStateInfo(0).IsName("ThomasLeftCrouch"))
            {
                animator.SetTrigger("LeftCrouchKick");
                isPunching = false;
                isKicking = true;
            }
        }
        void onDie()
        {
            if (thomasHealth.playerHealth <= 0)
            {
                Destroy(gameObject);
                thomasHealth.playerHealth = 10;
                ourScore.Score = 1;
                SceneManager.LoadScene("startScreen");
            }
        }
        void OneLife()
        {
            if (ourScore.Score % 3001 == 0)
            {
                thomasHealth.plusOne();
                ourScore.Score++;
            }
            else if (ourScore.Score % 3251 == 0)
            {
                thomasHealth.plusOne();
                ourScore.Score++;
            }
            else if (ourScore.Score % 3751 == 0)
            {
                thomasHealth.plusOne();
                ourScore.Score++;
            }
            else if (ourScore.Score % 3501 == 0)
            {
                thomasHealth.plusOne();
                ourScore.Score++;
            }
            else if (ourScore.Score % 3351 == 0)
            {
                thomasHealth.plusOne();
                ourScore.Score++;
            }
            else if (ourScore.Score % 3601 == 0)
            {
                thomasHealth.plusOne();
                ourScore.Score++;
            }
            else if (ourScore.Score % 3101 == 0)
            {
                thomasHealth.plusOne();
                ourScore.Score++;
            }

        }
    }

