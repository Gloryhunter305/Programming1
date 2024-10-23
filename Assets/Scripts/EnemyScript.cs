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
    public float requiredStamina;
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
            Vector2 direction = (Vector2)player.position - rb.position;

            if (currentStamina < 0)
            {
                runningMode = false;
            }

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




        // //Enemy will start with 0 stamina when the game starts *Recharge stamina
        // if (currentStamina <= maxStamina || currentStamina <= 0 && !rechargeMode)
        // {
        //     rb.velocity = rb.velocity / direction;
        //     currentStamina += rechargeRate * Time.deltaTime;
        //     rechargeMode = true;
        // }
        // //If enemy has enough stamina, they would start chasing player losing stamina while doing so
        // else if (currentStamina >= maxStamina && rechargeMode)
        // {
        //     rechargeMode = false;
        //     while (currentStamina > 0)
        //     {
        //         rb.velocity = direction * enemySpeed; // Adjust the speed to your liking
        //         currentStamina -= staminaUsageRate * Time.deltaTime;
        //     }
            
            
        // }
        

        

        
        //Debug.Log(direction);
        //direction.Normalize();
    }
}
