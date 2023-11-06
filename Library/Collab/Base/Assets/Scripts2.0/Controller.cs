using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{

    // NEWEST CODE

    // Global Variable
    public Rigidbody2D player1RigidBody;
    public Rigidbody2D player2RigidBody;
    public float moveSpeed;
    public float jumpforce;

    public Transform player1GroundPoint;
    public Transform player2GroundPoint;
    private bool player1IsOnGround;
    private bool player2IsOnGround;
    public LayerMask whatIsGround;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player1IsOnGround = Physics2D.OverlapCircle(player1GroundPoint.position, .2f, whatIsGround);
        player2IsOnGround = Physics2D.OverlapCircle(player2GroundPoint.position, .2f, whatIsGround);


        /************************************
        PLAYERS MOVEMENT
        ************************************/

        /********
        PLAYER 1
        *********/
        if (Input.GetKey(KeyCode.A))
        {
            player1RigidBody.velocity = new Vector2(-1 *moveSpeed ,player1RigidBody.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player1RigidBody.velocity = new Vector2(1*moveSpeed ,player1RigidBody.velocity.y);
        }
        if (Input.GetKey(KeyCode.W) && player1IsOnGround)
        {
            player1RigidBody.velocity = new Vector2(player1RigidBody.velocity.x,jumpforce );
        }


        /********
        PLAYER 2
        *********/
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player2RigidBody.velocity = new Vector2(-1*moveSpeed ,player2RigidBody.velocity.y);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player2RigidBody.velocity = new Vector2(1*moveSpeed ,player2RigidBody.velocity.y);
        }
        if (Input.GetKey(KeyCode.UpArrow) && player2IsOnGround)
        {
            player2RigidBody.velocity = new Vector2(player2RigidBody.velocity.x,jumpforce );
        }
        
     }
}



