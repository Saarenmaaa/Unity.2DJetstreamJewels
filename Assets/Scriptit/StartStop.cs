using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartStop : MonoBehaviour
{
    public GameObject startButton;
    public GameObject stopButton;
    public GameObject stopScreen;

    void Start()
    {
        startButton.SetActive(false);
        stopButton.SetActive(true);
        stopScreen.SetActive(false);
        AudioListener.volume = 1f;
    }

    public void StartButtonClick()
    {
        startButton.SetActive(false);
        stopButton.SetActive(true);
        stopScreen.SetActive(false);

        Time.timeScale = 1f;
        AudioListener.volume = 1f;
    }

    public void StopButtonClick()
    {
        startButton.SetActive(true);
        stopButton.SetActive(false);
        stopScreen.SetActive(true);
        Time.timeScale = 0f;

        AudioListener.volume = 0f;
    }
}
