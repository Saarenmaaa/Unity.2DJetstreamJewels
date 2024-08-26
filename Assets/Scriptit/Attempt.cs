using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attempt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Hide", 1.5f);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
