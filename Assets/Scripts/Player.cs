using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 5.0f;

    public float maxHeight = 4.0f;

    private Animation thisAnimation;

    private Rigidbody rb;

    public Text scoreText;
    
    private int playerScore = 0;


    void Start()
    {
        playerScore = 0;
        rb = GetComponent<Rigidbody>();
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        if (transform.position.y < maxHeight)
        {
            rb.velocity = new Vector2(0, jumpForce);
            thisAnimation.Play();
        }
    }

   

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScoreTrigger"))
        {
            playerScore += 10;
            scoreText.text = "SCORE : " + playerScore;
        }
    }
    
}
