using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Animation thisAnimation;
    private Rigidbody rb;
    public float JumpForce;
    public static int points;
    public Text pointTxt;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -10, 3.6f), transform.position.z);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, JumpForce, 0));
            thisAnimation.Play();
        }
        if (transform.position.y <= -4.5)
        {
            SceneManager.LoadScene("GameOver");
        }

        pointTxt.text = "Points: " + points;



    }
    
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Points")
        {
            points++;
            print("you collided");
        }
    }
}
