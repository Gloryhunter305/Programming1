using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    //These are the player's Variables, the raw info that defines them
    
    //The Rigidbody2D is a component that gives the player physics, and is what we use to move
    public Rigidbody2D RB;

    //TextMeshPro is a component that draws text on the screen.
    //We use this one to show our score.
    public TextMeshPro ScoreText;
    
    //This will control how fast the player moves
    [Header("Speed Component")]
    public float Speed = 5;
    public float dashSpeed;
    public bool canDash = true;

    [Header("Stamina Component")]
    public float maxStamina = 50f;
    public float currentStamina;
    public bool noStaminaLeft;
    //public Image staminaBar; // assign in the Inspector
    
    //This is how many points we currently have
    public int Score = 0;
    
    //Start automatically gets triggered once when the objects turns on/the game starts
    void Start()
    {
        //During setup we call UpdateScore to make sure our score text looks correct
        UpdateScore();

        //Initialize Stamina to be 100 every run
        currentStamina = maxStamina;
    }

    //Update is a lot like Start, but it automatically gets triggered once per frame
    //Most of an object's code will be called from Update--it controls things that happen in real time
    void Update()
    {
        /*      Check for Warp        */
        Warp();

        if (currentStamina >= maxStamina)
        {
            currentStamina = maxStamina;
        }
        else if (currentStamina <= 0)
        {
            currentStamina = 0;
        }

        /*      PLAYER MOVEMENT     */
        //First we make a variable that we'll use to record how we want to move
        Vector2 vel = new Vector2(0,0);
        
        /* Then we use if statement to figure out what that variable should look like */
        //If I hold the right arrow key, the player should move right. . .
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = Speed;
        }
        //If I hold the left arrow, the player should move left. . .
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -Speed;
        }
        //If I hold the up arrow, the player should move up. . .
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vel.y = Speed;
        }
        //If I hold the down arrow, the player should move down. . .
        if (Input.GetKey(KeyCode.DownArrow))
        {
            vel.y = -Speed;
        } 
        
        /*      STAMINA CONSUMPTION      */
        if (Input.GetKey(KeyCode.E) && !noStaminaLeft)
        {
            if (currentStamina > 0)
            {
                ReduceStamina(10f);
                RB.velocity = vel * dashSpeed; 
            }
            else
            {
                noStaminaLeft = true;
            } 
            
            //dashBuffer = 0;
            //canDash = false;
        } 
        else if (Input.GetKey(KeyCode.E) && noStaminaLeft) //WHETHER IF YOUR A BUG OR NOT, IDC, I WILL DEFEAT YOU FOR WASTING MY TIME!!!
        {
            RB.velocity = vel;
        }
        else
        {
            //Finally, I take that variable and I feed it to the component in charge of movement
            RB.velocity = vel; 

            if (currentStamina < maxStamina)
            {
                noStaminaLeft = false;
                RestoreStamina(2.5f);
            }
        }
    }

    //This gets called whenever you bump into another object, like a wall or coin.
    private void OnCollisionEnter2D(Collision2D other)
    {
        //This checks to see if the thing you bumped into had the Hazard tag
        //If it does...
        if (other.gameObject.CompareTag("Hazard"))
        {
            //Run your 'you lose' function!
            Die();
        }
        
        //This checks to see if the thing you bumped into has the CoinScript script on it
        CoinScript coin = other.gameObject.GetComponent<CoinScript>();
        //If it does, run the code block belows
        if (coin != null)
        {
            //Tell the coin that you bumped into them so they can self destruct or whatever
            coin.GetBumped();
            //Make your score variable go up by one. . .
            Score++;
            //And then update the game's score text
            UpdateScore();
        }
    }

    //This function updates the game's score text to show how many points you have
    //Even if your 'score' variable goes up, if you don't update the text the player doesn't know
    public void UpdateScore()
    {
        ScoreText.text = "Score: " + Score;
    }

    //If this function is called, the player character dies. The game goes to a 'Game Over' screen.
    public void Die()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void Warp()
    {
        if (transform.position.x > 11)
        {
            transform.position = new Vector2(-11, transform.position.y);
        }
        else if (transform.position.x < -11)
        {
            transform.position = new Vector2(11, transform.position.y);
        }

        if (transform.position.y > 5.5f)
        {
            transform.position = new Vector2(transform.position.x, -5.5f);
        }
        else if (transform.position.y < -5.5f)
        {
            transform.position = new Vector2(transform.position.x, 5.5f);
        }
    }

    public void ReduceStamina(float amount)
    {
        currentStamina -= amount * Time.deltaTime;
        //UpdateStaminaBar();
    }
    public void RestoreStamina(float amount)
    {
        currentStamina += amount * Time.deltaTime;
        //UpdateStaminaBar();
    }
    // private void UpdateStaminaBar()
    // {
    //     float staminaRatio = currentStamina / maxStamina;
    //     staminaBar.fillAmount = staminaRatio;
    // }
}
