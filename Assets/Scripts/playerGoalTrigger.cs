using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGoalTrigger : MonoBehaviour
{
    	public static int playerScore;					//total goals by player
	public static int cpuScore;						//total goals by cpu
    	//Reference to important game objects used inside the game

        
      //  public GameObject playerGoals;
	    public GameObject cpuGoals;
        public GameObject goalPlane;
        public GameObject ball;
        public GameObject player1;
        public GameObject player2;

        public Vector2 resetPosition;
        

        private GameObject clone=null;
       private bool canScore= true;



    void Awake(){
        playerScore = 0;
		cpuScore = 0;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision){
        Debug.Log(collision +"GameObject1 collided with " + collision.name);
        if(collision.CompareTag("Ball") && canScore){
            cpuScore++;
            //playerScore=playerScore;
            StartCoroutine(goalActions());
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        manageGoals();
        
    }

    void manageGoals() {
		cpuGoals.GetComponent<TextMesh>().text = cpuScore.ToString();
		//playerGoals.GetComponent<TextMesh>().text = playerScore.ToString();
	}
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
         //resets bal position
         ball.transform.position=resetPosition;
         // reset player1 and 2 position
         player1.transform.position=new Vector2(-4,player1.transform.position.y);
         player2.transform.position=new Vector2(4,player2.transform.position.y);
         
		ball.GetComponent<Rigidbody2D>().Sleep();
		ball.GetComponent<Rigidbody2D>().isKinematic = true;

		yield return new WaitForSeconds(1.5f);
        ball.GetComponent<Rigidbody2D>().isKinematic = false;
        canScore=true;
        
    }
}
