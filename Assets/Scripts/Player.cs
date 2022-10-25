using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;

    public int JumpSpeed = 30;
    Rigidbody rb;

    public int Score;
    public Text ScoreText;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * JumpSpeed;
            thisAnimation.Play();
        }
        
        //Maximum Height
        if(transform.position.y >= 3.6)
        {
            transform.position = new Vector3(transform.position.x, 3.6f, 0);
        }

        //GameOver
        else if(transform.position.y <= -4.3)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Score++;
            ScoreText.text = "SCORE : " + Score;
        }
    }
}
