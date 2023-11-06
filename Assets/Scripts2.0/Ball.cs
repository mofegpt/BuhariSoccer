// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Ball : MonoBehaviour
// {

//     private int collidedWithSomething;
//     public bool hasKickedBall;

//     private bool hasKickedBallConst;
//     public Rigidbody2D gameBall;
//     public Transform player1KickPoint;
//     public LayerMask whatIsBall;
//     public PhysicsMaterial2D superBouncyMaterial;
//     public PhysicsMaterial2D normalBouncyMaterial;

//     // Start is called before the first frame update
//     void Start()
//     {
//         collidedWithSomething = 0;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         hasKickedBall =  Physics2D.OverlapCircle(player1KickPoint.position, 0.5f, whatIsBall);
//         if (hasKickedBall) 
//         {
//             hasKickedBallConst = true;
//         }
//         Debug.Log(hasKickedBallConst);
//         if (collidedWithSomething > 2)
//             {
//                 Debug.Log("Collider!!!!");
//                 gameBall.sharedMaterial = normalBouncyMaterial;
//                 collidedWithSomething = 0;
//                 hasKickedBallConst = false;
//             }
        

//     }

//     private void OnCollisionEnter2D(Collision2D other) {
//             if (hasKickedBallConst)
//             {
//                 gameBall.sharedMaterial = superBouncyMaterial;
//                 collidedWithSomething ++;
//             } 
//     }
// } 
