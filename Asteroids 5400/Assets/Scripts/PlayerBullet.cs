using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    public Joystick joystick;
    Camera cam;
    public GameObject player;
    public float speed = 2000;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        joystick = FindObjectOfType<FixedJoystick>();
        asteroidSpawnerScript = FindObjectOfType<GameAsteroidSpawner>();
        gameHandlerScript = FindObjectOfType<GameHandler>();
        largeShipScript = FindObjectOfType<LargeShip>();

        float x = joystick.Direction.x;
        float y = joystick.Direction.y;

        if (x == 0 && y == 0)
        {
            y = 1;
        }

        dir = new Vector2(x, y).normalized;
    }

    Vector2 dir;

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = dir * speed * Time.deltaTime;
    }

    public GameAsteroidSpawner asteroidSpawnerScript;
    public GameHandler gameHandlerScript;
    public LargeShip largeShipScript;
    public SmallShip smallShipScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LargeAsteroid")
        {
            gameHandlerScript.PlayBangLarge();
            Destroy(this.gameObject);
            gameHandlerScript.ScoreValue += 20;
            gameHandlerScript.pointToLifeCounter += 20;
            asteroidSpawnerScript.SpawnMediumAsteroids(other.gameObject.transform.position);
            Destroy(other.gameObject);
        }else if (other.gameObject.tag == "MediumAsteroid")
        {
            gameHandlerScript.PlayBangMedium();
            Destroy(this.gameObject);
            gameHandlerScript.ScoreValue += 50;
            gameHandlerScript.pointToLifeCounter += 50;
            asteroidSpawnerScript.SpawnSmallAsteroids(other.gameObject.transform.position);
            Destroy(other.gameObject);
        }else if (other.gameObject.tag == "SmallAsteroid")
        {
            gameHandlerScript.PlayBangSmall();
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            gameHandlerScript.ScoreValue += 100;
            gameHandlerScript.pointToLifeCounter += 100;
        }else if (other.gameObject.tag == "SmallShip")
        {
            gameHandlerScript.PlaySaucerSmall();
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            gameHandlerScript.ScoreValue += 1000;
            gameHandlerScript.pointToLifeCounter += 1000;
            gameHandlerScript.smallShipOnScreen = false;
        }
        else if (other.gameObject.tag == "LargeShip")
        {
            gameHandlerScript.PlaySaucerBig();
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            gameHandlerScript.ScoreValue += 200;
            gameHandlerScript.pointToLifeCounter += 200;
            gameHandlerScript.largeShipOnScreen = false;
            largeShipScript.hasShipFired = false;
        }
    }

}
