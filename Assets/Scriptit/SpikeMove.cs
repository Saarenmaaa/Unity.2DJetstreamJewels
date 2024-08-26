using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMove : MonoBehaviour
{
    public float amplitude = 2.0f; // Set the amplitude of the movement
    public float speed = 2.0f; // Set the speed of the movement

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position based on sine function
        float newY = startPos.y + amplitude * Mathf.Sin(speed * Time.time);

        // Update the object's position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
