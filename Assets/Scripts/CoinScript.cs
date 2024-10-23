using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Collections;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    //The player calls this function on the coin whenever they bump into it
    //You can change its contents if you want something different to happen on collection
    //For example, what if the coin teleported to a new location instead of being destroyed?

    public float scanRadius = 2f;
    public LayerMask layerMask;
    private UnityEngine.Vector2 spawnPosition;
    private UnityEngine.Vector2 enemySpawnPosition;

    public GameObject enemySprite;

    public void Start()
    {
        layerMask = LayerMask.GetMask("Wall");
    }

    public bool IsSafeSpace(UnityEngine.Vector2 position)
    {
        // Cast a circle cast around the potential spawn position
        Collider2D[] hits = Physics2D.OverlapCircleAll(position, scanRadius, layerMask);

        // Check if there are any hits (i.e., overlap)
        return hits.Length == 0;
    }
    public void GetBumped()
    {   
        //This destroys the coin
        //Destroy(gameObject);
        float randomX = Random.Range(-10, 10);
        float randomY = Random.Range(-4.5f, 4.5f);
        

        spawnPosition = new UnityEngine.Vector2(randomX,randomY);

        if (IsSafeSpace(spawnPosition))
        {
            transform.position = new UnityEngine.Vector2(randomX, randomY);
            enemyChance();
            
        }
        else
        {
            Debug.Log("Spawn Overlapped. Randomizing another position...");
            GetBumped();
        }
        
        
        //transform.position = new Vector2(Random.Range(-10, 10), Random.Range(-4.5f,4.5f);
    }

    public void enemyChance()
    {
        float randomChance = Random.Range(0, 6);
        if (randomChance <= 1.2)
        {
            float randomXEnemy = Random.Range(-10, 10);
            float randomYEnemy = Random.Range(-4.5f, 4.5f);
            enemySpawnPosition = new UnityEngine.Vector2(randomXEnemy, randomYEnemy);

            if (IsSafeSpace(enemySpawnPosition))
            {
                Instantiate(enemySprite, new UnityEngine.Vector2(randomXEnemy,randomYEnemy), UnityEngine.Quaternion.identity);
            }
            else
            {
                Debug.Log("Enemy Spawn Overlap. Randomizing another position...");
                enemyChance();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, scanRadius);
    }    

}
