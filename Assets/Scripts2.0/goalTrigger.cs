using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalTrigger : MonoBehaviour
{
    public static int cpuScore;					//total goals by cpu(player2)
    public static int playerScore;			    //total goals by player1
    //Reference to important game objects used inside the game
        public GameObject ball;
        public GameObject goalPlane;
       public GameObject playerGoals;
        public GameObject cpuGoals;
      // public Vector2 resetPosition;
        public GameObject player1;
        public GameObject player2;
        


       private GameObject clone=null;
       private bool canScore= true;
       private bool p1Scored=false;
       private bool p2Scored=false;
	   private float ballPositioncheck;
       

       public GameObject goBall;
       public GameObject leftEffect, rightEffect;


    void Awake(){
       
		cpuScore = 0;
        playerScore = 0;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){

         Debug.Log("GameObject2 collided with " + other.name);
        ballPositioncheck= GameObject.FindGameObjectWithTag("Ball").transform.position.x;
           Debug.Log( GameObject.FindGameObjectWithTag("Ball").transform.position.x);

        if( ballPositioncheck>6 && other.CompareTag("Ball") && canScore ){
          Instantiate(goBall, rightEffect.transform.position, Quaternion.identity);
          p1Scored=true;
          StartCoroutine(goalActions());
             
            
        }
         if ( ballPositioncheck<-6 &&other.CompareTag("Ball")&& canScore ){
           Instantiate(goBall, leftEffect.transform.position, Quaternion.identity);
          p2Scored=true;
          StartCoroutine(goalActions());
            
            
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        manageGoals();
    }

    
     //activate the goal plane  and resets ball positions

    IEnumerator goalActions(){

        canScore=false;
        
//animation from right to middle
            clone = Instantiate (goalPlane);
            float t = 0;
			float speed = 2.0f;
			while(t < 1) {
				t += Time.deltaTime * speed;
				clone.transform.position = new Vector2(Mathf.SmoothStep(15, 0, t), 0);
				yield return 0;
			}
            yield return new WaitForSeconds(0.75f);
//animation from middle to left
			float t2 = 0;
			while(t2 < 1) {
				t2 += Time.deltaTime * speed;
				clone.transform.position = new Vector2(Mathf.SmoothStep(0, -15, t2), 0);
				yield return 0;
			}
		

	 
		Destroy(clone);
       //resets bal position and imcrements points
       if( p1Scored){
            ball.transform.position=new Vector2(3,3);
             playerScore++;
            
       }
          if(p2Scored){
            ball.transform.position=new Vector2(-3,3);
             cpuScore++;

       }

        player1.transform.position=new Vector2(-4,player1.transform.position.y);
         player2.transform.position=new Vector2(4,player2.transform.position.y);
         //freeze the ball for a while
		ball.GetComponent<Rigidbody2D>().Sleep();
		ball.GetComponent<Rigidbody2D>().isKinematic = true;

		yield return new WaitForSeconds(1.5f);
        ball.GetComponent<Rigidbody2D>().isKinematic = false;
        
        canScore=true;
        p1Scored=false;
        p2Scored=false;
    }

    void manageGoals() {
		cpuGoals.GetComponent<TextMesh>().text = cpuScore.ToString();
        playerGoals.GetComponent<TextMesh>().text = playerScore.ToString();
    }

}
