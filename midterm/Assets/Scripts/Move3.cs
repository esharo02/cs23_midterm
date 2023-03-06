using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move3 : MonoBehaviour


{
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    private BoxCollider2D boxCollider;
    public int count = 0;
    public GameHandler gameHandlerObj;
    private int collidedItemVal;
    private Animator anim;
    private Renderer rend;
    private SpriteRenderer spriteRenderer;


    public float speed = 0.2f;
    Vector3 pointA;
    Vector3 pointB;
    public Vector3 desiredTranform;
    float move = 0.01f;


    IEnumerator Start()
    {
        pointA = transform.position;
        pointB = transform.position + desiredTranform;

        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponentInChildren<Animator>();
        rend = GetComponentInChildren<Renderer>();


        if (GameObject.FindWithTag("GameHandler") != null)
        {
            gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }
        while (true)
        {
            anim.SetBool("walk", true);
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
            anim.SetBool("walk", false);
            yield return new WaitForSeconds(0.5f);


            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("walk", true);
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
            anim.SetBool("walk", false);
            yield return new WaitForSeconds(0.5f);
            transform.localScale = new Vector3(1, 1, 1);
        }

    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
}