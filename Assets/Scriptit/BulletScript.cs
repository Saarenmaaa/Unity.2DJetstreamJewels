using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject smallExplosion;
    public AudioClip räjähdys;

    void Update()
    {
        OffScreen();
    }

    void OffScreen()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPoint.x < 0 || screenPoint.x > Screen.width || screenPoint.y < 0 || screenPoint.y > Screen.height)
        {
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Map"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Spike"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("SpikeBall"))
        {
            Destroy(other.gameObject);
            Instantiate(smallExplosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(räjähdys, transform.position);
        }
        
    }
}
