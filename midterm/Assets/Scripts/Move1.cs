// using UnityEngine;

// public class Move2 : MonoBehaviour
// {
//     [SerializeField] private float speed = 5.0f; // movement speed
//     [SerializeField] private float maxDistance = 10.0f; // maximum distance the object can move
//     [SerializeField] private LayerMask obstacleLayer; // layer mask for obstacles
    
//     private Vector3 targetPosition; // position to move towards
    
//     private void Start()
//     {
//         targetPosition = GetRandomPosition(); // set initial target position
//     }

//     private void Update()
//     {
//         // move towards the target position
//         transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

//         // if the object has reached the target position, get a new target position
//         if (transform.position == targetPosition)
//         {
//             targetPosition = GetRandomPosition();
//         }
//     }

//     // returns a random position within the maximum distance that is not obstructed by any obstacles
//     private Vector3 GetRandomPosition()
//     {
//         Vector3 randomDirection = Random.insideUnitSphere * maxDistance;
//         randomDirection += transform.position;
//         NavMeshHit hit;
//         if (NavMesh.SamplePosition(randomDirection, out hit, maxDistance, NavMesh.AllAreas))
//         {
//             if (!Physics.CheckSphere(hit.position, 1.0f, obstacleLayer))
//             {
//                 return hit.position;
//             }
//         }
//         return GetRandomPosition();
//     }
// }
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move1 : MonoBehaviour


 {
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    private BoxCollider2D boxCollider;
    public int count = 0;
    public GameHandler gameHandlerObj;
    private int collidedItemVal;
    private Animator anim;
    private Renderer rend;

    
    public float speed = 2.0f;
     public float yPos;
     public Vector3 desiredPos;

     void Start()
     {
         yPos = Random.Range(-4.5f, 4.5f);
         desiredPos = new Vector3(transform.position.x, yPos, transform.position.z);
             boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponentInChildren<Animator>();
        rend = GetComponentInChildren<Renderer>();

    }
 
     void Update()
     {
         

            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.x), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
            if (hit.collider == null)
            {
            //anim.SetBool("walk", true); //art not updated
            transform.Translate(0, moveDelta.x * Time.deltaTime, 0);
            
        }

            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.y, 0), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
            if (hit.collider == null)
            {
           // anim.SetBool("walk", true);
            transform.Translate(moveDelta.y * Time.deltaTime, 0, 0);

        }
             transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * speed);
             if (Vector3.Distance(transform.position, desiredPos) <= 0.01f)
             {
           // anim.SetBool("walk", true);
            yPos = Random.Range(-4.5f, 4.5f);
                 desiredPos = new Vector3( transform.position.x ,yPos, transform.position.z);
            //  timer = 0.0f;
            }
                //anim.SetBool("walk", false);
         
         
     }
 }
// public float speed = 0.85f;

// Vector3 pointA;
// Vector3 pointB;
// public GameHandler gameHandlerObj;

// void Start()
// {
//     pointA = new Vector3(-6, 6, 0);
//     pointB = new Vector3(1, 6, 0);
//     if (GameObject.FindWithTag("GameHandler") != null)
//         {
//             gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
//         }
// }

// void Update()
// {
//     //PingPong between 0 and 1
//     if(gameHandlerObj.timeLeft > 0) {
//     float time = Mathf.PingPong(Time.time * speed, 1);
//     transform.position = Vector3.Lerp(pointA, pointB, time);
//     }
// }


// void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("Player")) {
//                     // Destroy(gameObject); /* remove picked up item */
//                     Debug.Log("hello?");
//                 }
//     }
// }