using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{

    public Transform player;
    public float enemySpeed;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (Vector2)player.position - rb.position;
        //Debug.Log(direction);
        //direction.Normalize();
        rb.velocity = direction * enemySpeed; // Adjust the speed to your liking
    }
}
