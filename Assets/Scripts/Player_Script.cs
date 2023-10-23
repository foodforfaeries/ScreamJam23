using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    public float maxSpeed = 15f;
    public float minSpeed = 10f;
    public float currentSpeed;
    public float accelSpeed = 0.05f;
    private Vector2 playerDirection;
    private Vector2 lastPlayerDirection;

    public Rigidbody2D myRigBod;

    // Start is called before the first frame update
    void Start()
    {
        myRigBod = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        playerDirection = new Vector2(directionX, directionY).normalized;

        if (playerDirection != Vector2.zero && currentSpeed < maxSpeed)
        {
            currentSpeed += accelSpeed;
        }
        else if (playerDirection == Vector2.zero && currentSpeed > minSpeed)
        {
            currentSpeed -= (accelSpeed);
        }
    }

    private void FixedUpdate()
    {
        if (playerDirection != Vector2.zero)
        {
            myRigBod.velocity = new Vector2(playerDirection.x * currentSpeed, playerDirection.y * currentSpeed);
            lastPlayerDirection = myRigBod.velocity;
        }
        else if (currentSpeed > minSpeed)
        {
            myRigBod.velocity = lastPlayerDirection;
        }
        else
        {
            myRigBod.velocity = Vector2.zero;
        }
        
    }
}
