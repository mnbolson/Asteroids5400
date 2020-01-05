using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawnner : MonoBehaviour
{

    public GameObject smallShip;
    public GameObject largeShip;

    GameHandler GameHandlerScript;
    LargeShip largeShipScript;
    SmallShip smallShipScript;
    Camera cam;

    public void Start()
    {
        cam = Camera.main;
        GameHandlerScript = FindObjectOfType<GameHandler>();
        
    }

    public void SpawnLargeShip(float spawnTime)
    {
        Instantiate(largeShip, RandomPosition(), Quaternion.identity);
        largeShipScript = FindObjectOfType<LargeShip>();
        largeShipScript.DestroyShip(10);
    }

    public void SpawnSmallShip(float spawnTime)
    {
        Instantiate(smallShip, RandomPosition(), Quaternion.identity);
        smallShipScript = FindObjectOfType<SmallShip>();
        smallShipScript.DestroyShip(spawnTime - 1);
    }

    float screenWidth = Screen.width;
    float screenHeight = Screen.height;

    private Vector3 RandomPosition()
    {
        float randomX = Random.Range(0, screenWidth);
        float randomY = Random.Range(0, screenHeight);

        Vector3 randomVector = new Vector3(randomX, randomY, 0);
        randomVector = cam.ScreenToWorldPoint(randomVector);
        randomVector.z = 0;

        return randomVector;
    }
}
