using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jetForce;
    public float sidewaysMultiplier;
    public Camera mainCamera;
    public Animator animator;
    private bool isGrounded;
    private bool JetPackOn;
    public LayerMask groundLayer;
    public GameObject explosionPrefab;
    public AudioSource gemÄäni;
    public AudioClip häviö;
    public GemChecker gemChecker;
    public AudioSource thruster;
    private bool soundOff = true;
    public GameController game;
    public TilemapController Move;
    public int ThisScene;

    void Start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {
        PlayerMovement();        
        ClampPlayerPosition();
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput > 0)
        {
            JetPackOn = true;
            if(soundOff && !isGrounded)
            {
                thruster.Play();
                soundOff = false;
            }
        }
        else
        {
            JetPackOn = false;
            thruster.Stop();
            soundOff = true;
        }

        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * 1f, Color.red);

        Vector2 movement = new Vector2(horizontalInput * sidewaysMultiplier, verticalInput);
        rb.velocity = movement * jetForce;
        animator.SetBool("JetPack", JetPackOn);
        animator.SetBool("Grounded", isGrounded);
    }

    void ClampPlayerPosition()
    {
        Vector3 playerPosition = transform.position;
        Vector3 viewPos = mainCamera.WorldToViewportPoint(playerPosition);

        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);

        playerPosition = mainCamera.ViewportToWorldPoint(viewPos);
        transform.position = new Vector3(playerPosition.x, playerPosition.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            Lose();
            gameObject.SetActive(false);
        }
        if (other.CompareTag("SpikeBall"))
        {
            Lose();
            gameObject.SetActive(false);
        }
        if (other.CompareTag("Gem"))
        {
            Destroy(other.gameObject);
            gemÄäni.Play();
            gemChecker.Gem();
        }
    }
    public void Lose()
    {
        Move.StartSpeed();
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(häviö, transform.position);
        Invoke("Again", 2.5f);
    }

    public void Again()
    {
        game.IncrementAttempt();
        SceneManager.LoadScene(ThisScene);
    }
}
