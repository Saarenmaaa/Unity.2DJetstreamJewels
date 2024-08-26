using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawColor : MonoBehaviour
{
    public float colorChangeSpeed = 1.0f;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        float colorChange = Mathf.PingPong(Time.time * colorChangeSpeed, 1.0f);

        Color purpleColor = new Color(0.5f, 0.0f, 0.5f); // Purple
        Color yellowColor = new Color(1.0f, 1.0f, 0.0f);  // Yellow
        Color lerpedColor = Color.Lerp(purpleColor, yellowColor, colorChange);


        spriteRenderer.color = lerpedColor;
    }
}
