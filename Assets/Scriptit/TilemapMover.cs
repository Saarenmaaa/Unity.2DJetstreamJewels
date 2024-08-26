using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TilemapController : MonoBehaviour
{
    public float scrollSpeedMax;
    public float startSpeed;
    private Transform tilemapTransform;
    public Transform startPoint;
    public Transform endPoint;
    public Transform Player;
    private float mapDistance;
    public TextMeshProUGUI textMeshPro;
    public GameObject winScreen;

    private void Start()
    {
        tilemapTransform = GetComponent<Transform>();
        mapDistance = endPoint.position.x - startPoint.position.x;
        winScreen.SetActive(false);
    }

    private void Update()
    {
        float distanceToEnd = endPoint.position.x - Player.position.x;
        float progression = 1f - distanceToEnd / mapDistance;
        float speed = Mathf.Lerp(startSpeed, scrollSpeedMax, progression);
        if(progression >= 1)
        {
            Win();            
        }

        float offsetX = Time.deltaTime * speed;
        tilemapTransform.Translate(Vector3.left * offsetX);
        textMeshPro.text = progression.ToString("P0");
    }


    private void Win()
    {
        Time.timeScale = 0f;
        winScreen.SetActive(true);
        // send diamonds and completed.

    }

    public void StartSpeed()
    {
        scrollSpeedMax = 0f;
        startSpeed = 0f;
    }
}



