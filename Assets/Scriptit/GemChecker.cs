using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemChecker : MonoBehaviour
{
    public List<GameObject> CanvasGemArray;
    public List<GameObject> WinGemArray;
    public GameController games;

    public void Gem()
    {
        GameObject firstGem = CanvasGemArray[0];
        Image gemImage = firstGem.GetComponent<Image>();
        Color currentColor = gemImage.color;
        currentColor.a = 1f;
        gemImage.color = currentColor;
        CanvasGemArray.RemoveAt(0);


        GameObject winGem = WinGemArray[0];
        Image winImage = winGem.GetComponent<Image>();
        Color winColor = winImage.color;
        winColor.a = 1f;
        winImage.color = winColor;
        WinGemArray.RemoveAt(0);

        games.addOne();
    }
}
