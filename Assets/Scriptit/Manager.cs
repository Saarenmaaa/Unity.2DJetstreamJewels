using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    public Image[] gems;
    public int gemNumber;
    public Button map2;
    public Button map3;
    public GameObject Lock2;
    public GameObject Lock3;


    void Start()
    {
        gemNumber = PlayerPrefs.GetInt("Level1", 0) + PlayerPrefs.GetInt("Level2", 0) + PlayerPrefs.GetInt("Level3", 0);
        Paint();
        Map2Open();
        Map3Open();
    }

    public void level1()
    {
        SceneManager.LoadScene(2);
    }

    public void level2()
    {
        SceneManager.LoadScene(3);
    }

    public void level3()
    {
        SceneManager.LoadScene(4);
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Paint()
    {
        for (int i = 0; i < gemNumber; i++)
        {
            Color imageColor = gems[i].color;
            imageColor.a = 1f;
            gems[i].color = imageColor;
        }
    }

    public void Map2Open()
    {
        map2.interactable = false;
        Lock2.SetActive(true);
        if(gemNumber >= 3)
        {
            map2.interactable = true;
            Lock2.SetActive(false);
        }
    }

    public void Map3Open()
    {
        map3.interactable = false;
        Lock3.SetActive(true);
        if(gemNumber >= 6)
        {
            map3.interactable = true;
            Lock3.SetActive(false);
        }
    }

    
}
