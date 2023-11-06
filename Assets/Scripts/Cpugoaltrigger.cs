using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cpugoaltrigger : MonoBehaviour
{
    						
	//public static int cpuScore;					//total goals by cpu
    public static int playerScore;			    //total goals by player
    //Reference to important game objects used inside the game
        public GameObject ball;
        public GameObject goalPlane;
       public GameObject playerGoals;
       public Vector2 resetPosition;
        public GameObject player1;
        public GameObject player2;



       private GameObject clone=null;
       private bool canScore= true;
	    //public GameObject cpuGoals;
       


    void Awake(){
       
		//cpuScore = 0;
        playerScore = 0;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){

         Debug.Log("GameObject2 collided with " + other.name);
        if(other.CompareTag("Ball")&& canScore){
            playerScore++;
            //call the goal plane function
            StartCoroutine(goalActions());
            
       
            
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        manageGoals();
    }

    void manageGoals() {
		//cpuGoals.GetComponent<TextMesh>().text = cpuScore.ToString();
        playerGoals.GetComponent<TextMesh>().text = playerScore.ToString();
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
        ball.transform.position=resetPosition;

        player1.transform.position=new Vector2(-4,player1.transform.position.y);
         player2.transform.position=new Vector2(4,player2.transform.position.y);
         //freeze the ball for a while
		ball.GetComponent<Rigidbody2D>().Sleep();
		ball.GetComponent<Rigidbody2D>().isKinematic = true;

		yield return new WaitForSeconds(1.5f);
        ball.GetComponent<Rigidbody2D>().isKinematic = false;
        
        canScore=true;
    }
}
