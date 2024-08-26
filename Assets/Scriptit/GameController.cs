using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TMP_Text attemptText;
    private int attempts = 0;
    public int gemCount;
    void Start()
    {
        attempts = PlayerPrefs.GetInt("AttemptCount", 1);
        UpdateAttemptText();
        gemCount = 0;
    }

    void UpdateAttemptText()
    {
        if (attemptText != null)
        {
            attemptText.text = "Attempt " + attempts;
        }
    }

    public void IncrementAttempt()
    {
        attempts++;
        UpdateAttemptText();
    }

    public void ResetAttempts()
    {
        attempts = 1;
        UpdateAttemptText();
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("AttemptCount", attempts);
        PlayerPrefs.Save();
    }

    public void Quit()
    {
        Application.Quit();
        ResetAttempts();
    }

    public void Menut()
    {
        ResetAttempts();
        SceneManager.LoadScene(1);
    }

    public void WinMenut1()
    {
        ResetAttempts();
        if(gemCount > PlayerPrefs.GetInt("Level1", 0))
        {
            PlayerPrefs.SetInt("Level1", gemCount);
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene(1);
    }
    public void WinMenut2()
    {
        ResetAttempts();
        if(gemCount > PlayerPrefs.GetInt("Level2", 0))
        {
            PlayerPrefs.SetInt("Level2", gemCount);
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene(1);
    }
    public void WinMenut3()
    {
        ResetAttempts();
        if(gemCount > PlayerPrefs.GetInt("Level3", 0))
        {
            PlayerPrefs.SetInt("Level3", gemCount);
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene(1);
    }

    public void addOne()
    {
        gemCount++;
        print(gemCount);
    }
}
