using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    Rigidbody2D RB;
    public Vector2 VelocityRange = new Vector2(-5, 5);
    Vector2 randomVelocity;
    Camera cam;
    GameHandler gameHandlerScript;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        RB = GetComponent<Rigidbody2D>();
        randomVelocity = RandomVelocity();
        gameHandlerScript = FindObjectOfType<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = randomVelocity;
    }

    private Vector2 RandomVelocity()
    {
        Vector2 Velocity = new Vector2(Random.Range(VelocityRange.x, VelocityRange.y + 1), Random.Range(VelocityRange.x, VelocityRange.y + 1));
        return Velocity;
    }

}
