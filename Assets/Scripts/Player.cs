using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;

    public int JumpSpeed = 30;
    Rigidbody rb;

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
            GameManager.thisManager.GameOver();
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            GameManager.thisManager.GameOver();
        }
    }
}
