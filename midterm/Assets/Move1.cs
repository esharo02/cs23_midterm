using UnityEngine;
using System.Collections;
 
public class Move1 : MonoBehaviour
{
    public float speed = 1.19f;
    Vector3 pointA;
    Vector3 pointB;

    void Start()
    {
        pointA = new Vector3(4, 3, 0);
        pointB = new Vector3(-2, 3, 0);
    }

    void Update()
    {
        //PingPong between 0 and 1
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
                    // Destroy(gameObject); /* remove picked up item */
                    Debug.Log("hello?");
                }
    }

    // void OnTriggerEnter2D(Collider2D other)
    //     {
    //         if (other.CompareTag("Player")) {
    //                     Debug.Log("hello?");
    //                 }
    //     }

    //     void OnTriggerEnter2D(Collision2D other)
    // {
    //     _rigidbody2D.position = _startPosition;
    //     _rigidbody2D.isKinematic = true;      
    // }

}