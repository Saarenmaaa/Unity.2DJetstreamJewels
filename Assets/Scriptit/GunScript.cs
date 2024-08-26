using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunScript : MonoBehaviour
{
   public GameObject bulletPrefab;
   public Transform firePoint;
   private float fireForce = 15f;
   public int clip;
   public TMP_Text ammo;
   public AudioSource shot;
   public AudioSource empty;


   void Update()
   {  
      ammo.text = clip.ToString();
      if(Input.GetButtonDown("Jump"))
      {
         Fire();
      }
   }
   public void Fire()
   {
      if(clip > 0)
      {
         shot.Play();
         GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
         bullet.transform.rotation = Quaternion.Euler(0f, 0f, firePoint.eulerAngles.z - 90f);
         bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireForce, ForceMode2D.Impulse);
         clip --;
      }
      else
      {
         empty.Play();
      }
   }
}

