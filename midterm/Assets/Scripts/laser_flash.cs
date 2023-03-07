using UnityEngine;
using System.Collections;

public class laser_flash : MonoBehaviour
{
    public float blinkInterval = 0.5f; // Time in seconds between each blink
    public float blinkDuration = 0.1f; // Time in seconds for each blink
    public GameObject laserArt;

    private bool isBlinking = false;
    private Renderer renderer;
    private BoxCollider2D boxCollider;

    void Start()
    {
        renderer = laserArt.GetComponent<Renderer>();
        //boxCollider = GetComponent<BoxCollider2D>;
    }

    void Update()
    {
        if (!isBlinking)
        {
            StartCoroutine(Blink());
        }
    }

    IEnumerator Blink()
    {
        isBlinking = true;
        renderer.enabled = false;
        this.GetComponent<Collider2D>().enabled = false;
        this.GetComponentInChildren<SpriteMask>().enabled = false;
        yield return new WaitForSeconds(blinkDuration);
        renderer.enabled = true;
        this.GetComponent<Collider2D>().enabled = true;
        this.GetComponentInChildren<SpriteMask>().enabled = true;
        yield return new WaitForSeconds(blinkInterval - blinkDuration);
        isBlinking = false;
    }
}
