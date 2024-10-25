using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.AI;

public class WightScript : MonoBehaviour
{
    [SerializeField] PlayerScript player;

    public int newEnemyUnlocked;
    private Vector2 playerPos;

    [Header("Random Position")]
    public int xOffset = 1;
    public int yOffset = 1;

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

            //transform.position = new Vector2(0 + xOffset, 0 + yOffset);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
