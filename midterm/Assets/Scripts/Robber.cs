using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robber : MonoBehaviour
{
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    private BoxCollider2D boxCollider;
    public int count = 0;
    public GameHandler gameHandlerObj;
    private int collidedItemVal;
    private Animator anim;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rend = GetComponentInChildren<Renderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        if (GameObject.FindWithTag("GameHandler") != null)
        {
            gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameHandlerObj.timeLeft > 0)
        {
            float x = Input.GetAxisRaw("Horizontal") * 3;
            float y = Input.GetAxisRaw("Vertical") * 3;
            moveDelta = new Vector3(x, y, 0);
            if (moveDelta.x > 0)
            {
            
                transform.localScale = new Vector3(1, 1, 1);
                anim.SetBool("walk", true);

            }
            else if (moveDelta.x < 0)
            {
             
                transform.localScale = new Vector3(-1, 1, 1);
                anim.SetBool("walk", true);

            } else if (moveDelta.y != 0) {
                anim.SetBool("walk", true);
            } else {
                anim.SetBool("walk", false);
            }


            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
            if (hit.collider == null)
            {
                transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
            }

            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
            if (hit.collider == null)
            {
                transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("cop"))
        {
            count++;
            gameHandlerObj.RemoveScore(1);
            gameHandlerObj.ReduceTime(5);
            {
                //Debug.Log("Exceeded 3 hits. You lose");

                Vector3 pointA;
                Vector3 pointB;

                pointA = new Vector3(-6, 6, 0);
                pointB = new Vector3(1, 6, 0);

                //PingPong between 0 and 0
                float time = Mathf.PingPong(Time.time * 0f, 1);
                transform.position = Vector3.Lerp(pointA, pointB, time);
            }
            Debug.Log("GUARD hit --total " + count);
            transform.position = new Vector3(0, 0, 0);
            //_rigidbody2D.isKinematic = true;
            //Destroy(gameObject);
        }
    //    laser_flash theLAZER = GameObject.Find("laserbeam").GetComponent<laserbeam>();
        if (other.CompareTag("laserbeam"))
        {
            count++;
            gameHandlerObj.RemoveScore(1);
            gameHandlerObj.ReduceTime(5);
            
                Vector3 pointA;
                Vector3 pointB;

                pointA = new Vector3(-6, 6, 0);
                pointB = new Vector3(1, 6, 0);

                //PingPong between 0 and 0
                float time = Mathf.PingPong(Time.time * 0f, 1);
                transform.position = Vector3.Lerp(pointA, pointB, time);
            
            Debug.Log("LAZER hit --total " + count);
            transform.position = new Vector3(0, 0, 0);
        }

    }
    
}
