using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject playerBullet;
    public GameObject Player;
    bool playerDead = false;
    Rigidbody2D playerRB;

    public Joystick joystick;
    float angle = 0;

    private Vector2 thrust;
    public float thrustMultiplyer = 10f;
    
    public Camera cam;

    GameAsteroidSpawner asteroidSpawnerScript;
    GameHandler gameHandlerScript;
    SpawnZone spawnZoneScript;

    float screenWidth = Screen.width;
    float screenHeight = Screen.height;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Application.targetFrameRate = 60;

        playerRB = Player.GetComponent<Rigidbody2D>();

        gameHandlerScript = FindObjectOfType<GameHandler>();
        asteroidSpawnerScript = FindObjectOfType<GameAsteroidSpawner>();
        spawnZoneScript = FindObjectOfType<SpawnZone>();
    }

    // Update is called once per frame
    void Update()
    {
        //ScreenWrap();

        Vector3 shipRotation = new Vector3(0, 0, CalcJoystickAngle());
        Player.transform.rotation = Quaternion.Euler(shipRotation);

        CheckIfPlayerCanRespawn();

    }

    /* Kill Player if Hit And Respawn Player */

    private void OnTriggerEnter2D(Collider2D collision) {
        if (playerDead != true) {
            if (collision.gameObject.tag == "MediumAsteroid") {
                gameHandlerScript.PlayBangMedium();
                Destroy(collision.gameObject);
                asteroidSpawnerScript.SpawnSmallAsteroids(collision.gameObject.transform.position);
            }
            else if (collision.gameObject.tag == "LargeAsteroid") {
                gameHandlerScript.PlayBangLarge();
                Destroy(collision.gameObject);
                asteroidSpawnerScript.SpawnMediumAsteroids(collision.gameObject.transform.position);
            }
            else if (collision.gameObject.tag == "SmallAsteroid") {
                gameHandlerScript.PlayBangSmall();
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "SmallShip") {
                gameHandlerScript.PlaySaucerSmall();
                Destroy(collision.gameObject);
                gameHandlerScript.smallShipOnScreen = false;
            }
            else if (collision.gameObject.tag == "LargeShip") {
                gameHandlerScript.PlaySaucerBig();
                Destroy(collision.gameObject);
                gameHandlerScript.largeShipOnScreen = false;
            }
            else if (collision.gameObject.tag == "ShipBullets") {
                gameHandlerScript.PlayBangLarge();
                Destroy(collision.gameObject);
            }

            gameHandlerScript.CurrentLives -= 1;
            playerDead = true;
            Player.SetActive(false);
        }
    }

    public void CheckIfPlayerCanRespawn() {
        if (playerDead == true) {
            if (spawnZoneScript.SafeToSpawn == true) {
                Player.transform.position = new Vector3(0, 0, 0);
                playerDead = false;
            }
            else {
                playerDead = true;
            }
        }
    }

    /* Player Shooting Script */

    public void ShootPlayerBullet()
    {
        if (!playerDead) {
            float x = joystick.Direction.x;
            float y = joystick.Direction.y;

            PlayerBullet[] bullets = FindObjectsOfType<PlayerBullet>();
            int numberOfBullets = bullets.Length;

            gameHandlerScript.PlayFire();

            if (numberOfBullets <= 3)
            {
                if (x == 0 && y == 0)
                {
                    GameObject myBullet = Instantiate(playerBullet, Player.transform.position, this.transform.rotation);
                    Destroy(myBullet, 2);
                }
                else
                {
                    GameObject myBullet = Instantiate(playerBullet, Player.transform.position, this.transform.rotation);
                    Destroy(myBullet, 2);
                }
            }else
            {
                Destroy(bullets[numberOfBullets - 1].gameObject);
                GameObject myBullet = Instantiate(playerBullet, Player.transform.position, this.transform.rotation);
                Destroy(myBullet, 2);
            }
        }
    }

    /* Game Scene Buttons */

    private Vector3 RandomWarpPosition()
    {
        Vector3 WarpPixelPosition = new Vector3(Random.Range(0, screenWidth), Random.Range(0, screenHeight), 0);
        Vector3 WarpViewPortPosition = cam.ScreenToWorldPoint(WarpPixelPosition);
        WarpViewPortPosition.z = 0;

        return WarpViewPortPosition;
    }

    public void WarpButton()
    {

        if (Time.timeScale != 0)
        {
            Player.transform.position = RandomWarpPosition();
        }
    }

    public void ThrustButton()
    {
        if (Time.timeScale != 0)
        {
            thrust = new Vector2(joystick.Direction.x, joystick.Direction.y).normalized * thrustMultiplyer;

            if (thrust.x == 0.0f || thrust.y == 0.0f)
            {
                thrust = new Vector2(0, 1) * thrustMultiplyer;
            }

            gameHandlerScript.PlayThrust();
            playerRB.AddForce(thrust);
        }
    }

    /* Joystick Angle Calculation */

    private float CalcJoystickAngle()
    {
        float x = joystick.Direction.x;
        float y = joystick.Direction.y;

        if (x < 0 && y >= 0)
        {
            //Quad 1
            x = Mathf.Abs(x);
            y = Mathf.Abs(y);
            angle = Mathf.Rad2Deg * Mathf.Atan(x / y);
        }
        else if (x < 0 && y < 0)
        {
            //Quad 2
            angle = 180 - Mathf.Rad2Deg * Mathf.Atan(x / y);
        }
        else if (x >= 0 && y < 0)
        {
            //Quad 3
            x = Mathf.Abs(x);
            y = Mathf.Abs(y);
            angle = 180 + Mathf.Rad2Deg * Mathf.Atan(x / y);
        }
        else if (x >= 0 && y >= 0)
        {
            //Quad 4
            angle = 360 - Mathf.Rad2Deg * Mathf.Atan(x / y);
        }

        
        if (float.IsNaN(angle))
        {
            return 0;
        }else
        {
            return angle;
        }   
    }
}
