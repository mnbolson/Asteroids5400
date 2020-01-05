using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeShip : MonoBehaviour
{

    Camera cam;
    Rigidbody2D RB;
    GameHandler gameHandlerScript;

    public GameObject enemyBullet;
    public GameObject largeShip;
    public Vector2 VelocityRange = new Vector2(-5, 5);
    
    bool isWrappingX = false;
    bool isWrappingY = false;

    float screenWidth = Screen.width;
    float screenHeight = Screen.height;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        RB = GetComponent<Rigidbody2D>();
        RB.velocity = RandomVelocity();

        gameHandlerScript = FindObjectOfType<GameHandler>();

        StartCoroutine(shootShipBullet());
    }

    public bool hasShipFired = false;

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator shootShipBullet()
    {
        float randomTime = Random.Range(0, 2);
        yield return new WaitForSeconds(randomTime);
        hasShipFired = true;
        ShootEnemyBullet();
    }

    private void ShootEnemyBullet()
    {
        GameObject myBullet = Instantiate(enemyBullet, this.transform.position, this.transform.rotation);
        Destroy(myBullet, 3);
    }

    public void DestroyShip(float destroyTime)
    {
        Destroy(this.gameObject, destroyTime);
        
        StartCoroutine(allowShipSpawnAgain(destroyTime - 1));
    }

    IEnumerator allowShipSpawnAgain(float ResetLargeShip)
    {
        yield return new WaitForSeconds(ResetLargeShip);
        gameHandlerScript.largeShipOnScreen = false;
    }

    private Vector2 RandomVelocity()
    {
        Vector2 Velocity = new Vector2(Random.Range(VelocityRange.x, VelocityRange.y + 1), Random.Range(VelocityRange.x, VelocityRange.y + 1));
        return Velocity;
    }

    
}
