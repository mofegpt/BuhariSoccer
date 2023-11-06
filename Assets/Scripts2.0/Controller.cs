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

    //public Rigidbody2D Ball;
    public float moveSpeed;
    public float jumpforce;

    public Transform player1GroundPoint;
    public Transform player2GroundPoint;
    private bool player1IsOnGround;
    private bool player2IsOnGround;

    public Animator player1Anim;
    public Animator player2Anim;
    public LayerMask whatIsGround;
    public LayerMask whatIsBall;





    
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
            move(-1, player1RigidBody);
        }
        if (Input.GetKey(KeyCode.D))
        {
            move(1, player1RigidBody);
        }
        if (Input.GetKeyDown(KeyCode.W) && player1IsOnGround)
        {
           jump(player1RigidBody);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player1Anim.SetBool("hasClickedSpace", true);
        }
         if (Input.GetKeyUp(KeyCode.Space))
          {
            player1Anim.SetBool("hasClickedSpace", false);
        }


        /********
        PLAYER 2
        *********/
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move(-1, player2RigidBody);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            move(1, player2RigidBody);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && player2IsOnGround)
        {
            jump(player2RigidBody);
            
    
        }
    
        if (Input.GetKeyDown(KeyCode.C))
        {
            player2Anim.SetBool("hasClickedMouse", true);

        }
         if (Input.GetKeyUp(KeyCode.C))
        {
            player2Anim.SetBool("hasClickedMouse", false);
        }
    player2Anim.SetBool("hasJumped", player2IsOnGround);
    
     }

     void move(float xDirection, Rigidbody2D rigidbody)
     {
         rigidbody.velocity = new Vector2 (xDirection * moveSpeed, rigidbody.velocity.y);
     }
     void jump(Rigidbody2D rigidbody)
     {
         //player2Anim.SetBool("hasJumped", true);
         rigidbody.velocity = new Vector2(rigidbody.velocity.x,jumpforce );
         
     }
    
}



