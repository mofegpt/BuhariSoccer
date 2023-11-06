using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
	//public float startingX = 0.0f;
	//private Vector2 startingPosition;

    
	//reference to child game objects
	public Rigidbody2D myShoe;
	public GameObject ball;
	public Rigidbody2D player1RigidBody;
    public Rigidbody2D player2RigidBody;
	public float rotationTorque;
	public float shootforce;
	//private float maxShoeTurn = 45.0f; 		//in degrees

	public bool canTurnHead = true;			//flag
	public bool canTurnShoe = true;			//flag
	 public Transform player1GroundPoint;
    public Transform player2GroundPoint;
	private bool player1IsOnGround;
    private bool player2IsOnGround;
	private  float originalShoeRotation;

	public float moveSpeed;		//player movement speed
	public float jumpforce;		//player jump power (avoid setting it higher than 400)
	//private bool canJump = true;
	public LayerMask whatIsGround;


    // Start is called before the first frame update
    void Start()
    {
        //startingPosition = new Vector2(startingX, 0.0f);
		//transform.position = startingPosition;
    
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
        if (Input.GetKeyDown(KeyCode.W) && player1IsOnGround)
        {
            player1RigidBody.velocity = new Vector2(player1RigidBody.velocity.x,jumpforce );
        }

		if(Input.GetKey(KeyCode.Space)){
			
			 myShoe.AddForce(new Vector2(2,shootforce),ForceMode2D.Force);
		
		// if(myShoe.rotation==rotationTorque){

       	// 	myShoe.rotation = 0f;
		// }
			
			//myShoe.rotation -=rotationTorque;
			//rotationTorque=0;
			// myShoe.AddTorque(rotationTorque,ForceMode2D.Force);
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
        if (Input.GetKeyDown(KeyCode.UpArrow) && player2IsOnGround)
        {
            player2RigidBody.velocity = new Vector2(player2RigidBody.velocity.x,jumpforce );
        }

		// if(myShoe.rotation>10){

		// 	myShoe.rotation=0f;
		// 	}
	
	}

	void FixedUpdate()
    { 
		
    }
  
    void resetTurn()
	{
		myShoe.rotation=0f;
	}
    //     void rotateShoe() {

	// 	if(!myShoe || !canTurnShoe)
	// 		return;

	// 	float rotateMinVelocity = 0.1f;

	// 	if(GetComponent<Rigidbody2D>().velocity.x >= rotateMinVelocity) {
	// 		myShoe.transform.localEulerAngles = new Vector3(0, maxShoeTurn, 180);
	// 	} else if(GetComponent<Rigidbody2D>().velocity.x <= rotateMinVelocity * -1) {
	// 		myShoe.transform.localEulerAngles = new Vector3(0, maxShoeTurn * -1, 180);
	// 	} else {
	// 		myShoe.transform.localEulerAngles = new Vector3(0, 0, 180);
	// 	}
	// }

	// void rotateHead(int _dir) {

	// 	if(!canTurnHead)
	// 		return;

	// 	if(myHead) {
	// 		//swing the head by setting a new rotation for the spring
	// 		JointSpring js = myHead.GetComponent<HingeJoint2D>().spring;
	// 		js.targetPosition = 15 * _dir;
	// 		myHead.GetComponent<HingeJoint2D>().spring = js;
	// 	}
	// }

    /// Move player with keyboard keys.


}