using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{

    public Transform player;
    public float enemySpeed;


    [Header("Stamina Component")]
    public bool runningMode = false;
    public float maxStamina;
    public float rechargeRate;
    public float staminaUsageRate;
    public float currentStamina;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Enemy has two states, Running State and Recharging State

        if (runningMode)
        {
            //Grabs the player's location throughout the game
            Vector2 direction = (Vector2)player.position - rb.position;

            if (currentStamina < 0)
            {
                runningMode = false;
            }
            //Chases the player while wasting their stamina
            rb.velocity = direction * enemySpeed;
            currentStamina -= staminaUsageRate * Time.deltaTime;
        }
        if (!runningMode)
        {
            rb.velocity = Vector2.zero;
            if (currentStamina > maxStamina)
            {
                runningMode = true;
            }
            currentStamina += rechargeRate * Time.deltaTime;
        }
        
        //Debug.Log(direction);
        //direction.Normalize();
    }
}
