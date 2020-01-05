using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{

    PlayerMovement playerMovementScript;
    public bool SafeToSpawn = true;

    void Start()
    {
        playerMovementScript = FindObjectOfType<PlayerMovement>();

    }

    private void Update()
    {

        /* If the Spawn Zone is empty the player will be reactivited and moved to
        the middle of the screen */
        if (SafeToSpawn)
        {
            playerMovementScript.Player.SetActive(true);
        }

    }

    //Detects if an  object is currently in the Spawn Zone. 
    private void OnTriggerStay2D(Collider2D collision)
    {
        //print("cant spawn player not safe to spawn player");
        SafeToSpawn = false;
    }

    //Detects if an  object has left the Spawn Zone. 
    private void OnTriggerExit2D(Collider2D collision)
    {
        //print("Safe to spawn player");
        SafeToSpawn = true;

        playerMovementScript.Player.SetActive(true);

    }
}
