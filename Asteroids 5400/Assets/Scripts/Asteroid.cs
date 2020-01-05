using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    Camera cam;
    public Vector2 VelocityRange = new Vector2(-3,5);
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        //this.GetComponent<Rigidbody2D>().velocity = RandomVelocity();
        asteroidVelocity = RandomVelocity();
    }

    public Vector2 asteroidVelocity;

    // Update is called once per frame
    void Update()
    {
        
        this.GetComponent<Rigidbody2D>().velocity = asteroidVelocity;
    }

    private Vector2 RandomVelocity()
    {
        Vector2 Velocity = new Vector2(Random.Range(VelocityRange.x, VelocityRange.y + 1), Random.Range(VelocityRange.x, VelocityRange.y + 1));
        return Velocity;
    }
}
