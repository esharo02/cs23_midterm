using UnityEngine;
using System.Collections;

public class laser_flash : MonoBehaviour
{
    public float blinkInterval = 0.5f; // Time in seconds between each blink
    public float blinkDuration = 0.1f; // Time in seconds for each blink

    private bool isBlinking = false;
    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
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
        yield return new WaitForSeconds(blinkDuration);
        renderer.enabled = true;
        yield return new WaitForSeconds(blinkInterval - blinkDuration);
        isBlinking = false;
    }
}
