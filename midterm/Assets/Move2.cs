using UnityEngine;
using System.Collections;
 
public class Move2 : MonoBehaviour
{
public float speed = 0.85f;
Vector3 pointA;
Vector3 pointB;
public GameHandler gameHandlerObj;

void Start()
{
    pointA = new Vector3(-6, 6, 0);
    pointB = new Vector3(1, 6, 0);
    if (GameObject.FindWithTag("GameHandler") != null)
        {
            gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }
}

void Update()
{
    //PingPong between 0 and 1
    if(gameHandlerObj.timeLeft > 0) {
    float time = Mathf.PingPong(Time.time * speed, 1);
    transform.position = Vector3.Lerp(pointA, pointB, time);
    }
}


void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
                    // Destroy(gameObject); /* remove picked up item */
                    Debug.Log("hello?");
                }
    }
}