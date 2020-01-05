using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallShip : MonoBehaviour
{

    public GameObject enemyBullet;
    public GameObject smallShip;
    //public GameObject player;

    Rigidbody2D RB;
    GameHandler gameHandlerScript;

    [HideInInspector]
    public Vector2 VelocityRange = new Vector2(-3, 3);

    bool isWrappingX = false;
    bool isWrappingY = false;

    float screenWidth = Screen.width;
    float screenHeight = Screen.height;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        RB = GetComponent<Rigidbody2D>();
        RB.velocity = RandomVelocity();

        StartCoroutine(shootShipBullet());
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    IEnumerator shootShipBullet()
    {
        float randomTime = Random.Range(0, 2);
        yield return new WaitForSeconds(randomTime);
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

    IEnumerator allowShipSpawnAgain(float ResetShip)
    {
        yield return new WaitForSeconds(ResetShip);
        gameHandlerScript.largeShipOnScreen = false;
    }

    private Vector2 RandomVelocity()
    {
        Vector2 Velocity = new Vector2(Random.Range(VelocityRange.x, VelocityRange.y + 1), Random.Range(VelocityRange.x, VelocityRange.y + 1));
        return Velocity;
    }
}
