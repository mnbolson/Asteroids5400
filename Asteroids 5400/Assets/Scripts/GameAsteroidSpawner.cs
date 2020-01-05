using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAsteroidSpawner : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject mediumAsteroid;
    public GameObject smallAsteroid;

    public Sprite AsteroidOne;
    public Sprite AsteroidTwo;
    public Sprite AsteroidThree;

    public Sprite MediumAsteroidOne;
    public Sprite MediumAsteroidTwo;
    public Sprite MediumAsteroidThree;

    public Sprite SmallAsteroidOne;
    public Sprite SmallAsteroidTwo;
    public Sprite SmallAsteroidThree;

    Camera cam;

    //public int numberOfAsteroidsRemaining;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        SpawnLargeInitialAsteroids();
    }

    // Update is called once per frame
    void Update()
    {
        CheckNumberOfCurrentAsteroids();
    }

    /* Spawn More Asteroids if no more are left */
    public void CheckNumberOfCurrentAsteroids()
    {
        int numberOfAsteroidsRemaining = FindObjectsOfType<Asteroid>().Length;

        if (numberOfAsteroidsRemaining <= 0)
        {
            SpawnLargeInitialAsteroids();
        }
    }

    /* Spawn Medium Asteroids */
    public void SpawnMediumAsteroids(Vector3 position)
    {
        
        int numberOfMediumAsteroids = 2;

        for (int i = 0; i < numberOfMediumAsteroids; i++)
        {
            MediumAsteroidSkin();
            Instantiate(mediumAsteroid, position, Quaternion.identity);
            mediumAsteroid.tag = "MediumAsteroid";
        }
    }

    /* Spawn Small Asteroids */
    public void SpawnSmallAsteroids(Vector3 position)
    {
        
        int numberOfSmallAsteroids = 2;

        for (int i = 0; i < numberOfSmallAsteroids; i++)
        {
            SmallAsteroidSkin();
            Instantiate(smallAsteroid, position, Quaternion.identity);
            smallAsteroid.tag = "SmallAsteroid";
        }
    }

    /* Spawn Initial Asteroids */
    private void SpawnLargeInitialAsteroids()
    {
        
        int numberOfLargeAsteroids = Random.Range(4, 7);

        for (int i = 0; i <= numberOfLargeAsteroids ; i++)
        {
            LargeAsteroidSkin();
            Instantiate(asteroid, RandomPosition(), Quaternion.identity);
        }
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

    private void LargeAsteroidSkin()
    {
        switch (Random.Range(1, 4))
        {
            case 1:
                asteroid.GetComponent<SpriteRenderer>().sprite = AsteroidOne;
                break;
            case 2:
                asteroid.GetComponent<SpriteRenderer>().sprite = AsteroidTwo;
                break;
            case 3:
                asteroid.GetComponent<SpriteRenderer>().sprite = AsteroidThree;
                break;
        }
    }

    private void MediumAsteroidSkin()
    {
        switch (Random.Range(1, 4))
        {
            case 1:
                mediumAsteroid.GetComponent<SpriteRenderer>().sprite = MediumAsteroidOne;
                break;
            case 2:
                mediumAsteroid.GetComponent<SpriteRenderer>().sprite = MediumAsteroidTwo;
                break;
            case 3:
                mediumAsteroid.GetComponent<SpriteRenderer>().sprite = MediumAsteroidThree;
                break;
        }
    }

    private void SmallAsteroidSkin()
    {
        switch (Random.Range(1, 4))
        {
            case 1:
                smallAsteroid.GetComponent<SpriteRenderer>().sprite = SmallAsteroidOne;
                break;
            case 2:
                smallAsteroid.GetComponent<SpriteRenderer>().sprite = SmallAsteroidTwo;
                break;
            case 3:
                smallAsteroid.GetComponent<SpriteRenderer>().sprite = SmallAsteroidThree;
                break;
        }
    }
}
