using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.AI;

public class WightScript : MonoBehaviour
{
    [SerializeField] PlayerScript player;

    public int newEnemyUnlocked;
    private Vector2 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerScript>();
    }

    public void theWightWillAppearNow()
    {
        int currentScore = player.getScore();

        if (currentScore > newEnemyUnlocked)
        {
            //Grabs player's position
            playerPos = player.transform.position;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
