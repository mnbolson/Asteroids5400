using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartBullet : MonoBehaviour
{

    Rigidbody2D RB;
    [HideInInspector]
    public Vector2 VelocityRange = new Vector2(-5, 5);
    Vector2 targetVelocity;
    Camera cam;
    GameHandler gameHandlerScript;

    float moveSpeed = 4;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        RB = GetComponent<Rigidbody2D>();

        TargetVelocity();

        gameHandlerScript = FindObjectOfType<GameHandler>();
    }

    public void TargetVelocity()
    {
        targetVelocity = (target.transform.position - this.gameObject.transform.position).normalized * moveSpeed;
        
    }


    // Update is called once per frame
    void Update()
    {
        RB.velocity = targetVelocity;
    }

}
