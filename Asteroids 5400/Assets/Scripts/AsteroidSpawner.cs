using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    public GameObject asteroid;
    public Sprite AsteroidOne;
    public Sprite AsteroidTwo;
    public Sprite AsteroidThree;

    public Sprite MediumAsteroidOne;
    public Sprite MediumAsteroidTwo;
    public Sprite MediumAsteroidThree;

    public Sprite SmallAsteroidOne;
    public Sprite SmallAsteroidTwo;
    public Sprite SmallAsteroidThree;

    // Start is called before the first frame update
    void Start()
    {
        SpawnAsteroid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnAsteroid()
    {
        //Large Asteroids
        for (int i = 0; i < 4; i++)
        {
            RandomAsteroid();

            Instantiate(asteroid, new Vector3(i * 1.25f, 3, 0), Quaternion.identity);
        }

        //Medium asteroids
        for (int i = 0; i < 4; i++)
        {
            MediumAsteroidMaker();

            Instantiate(asteroid, new Vector3(i * 1.25f, 0, 0), Quaternion.identity);
        }

        //Medium asteroids
        for (int i = 0; i < 4; i++)
        {
            SmallAsteroidMaker();

            Instantiate(asteroid, new Vector3(i * 1.25f, -3, 0), Quaternion.identity);
        }

    }

    private void SmallAsteroidMaker()
    {
        switch (Random.Range(1, 4))
        {
            case 1:
                asteroid.GetComponent<SpriteRenderer>().sprite = SmallAsteroidOne;
                break;
            case 2:
                asteroid.GetComponent<SpriteRenderer>().sprite = SmallAsteroidTwo;
                break;
            case 3:
                asteroid.GetComponent<SpriteRenderer>().sprite = SmallAsteroidThree;
                break;
        }
    }


    private void MediumAsteroidMaker()
    {
        switch (Random.Range(1, 4))
        {
            case 1:
                asteroid.GetComponent<SpriteRenderer>().sprite = MediumAsteroidOne;
                break;
            case 2:
                asteroid.GetComponent<SpriteRenderer>().sprite = MediumAsteroidTwo;
                break;
            case 3:
                asteroid.GetComponent<SpriteRenderer>().sprite = MediumAsteroidThree;
                break;
        }
    }

    private void RandomAsteroid()
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
}
