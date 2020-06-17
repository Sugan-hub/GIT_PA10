using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.WSA;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private int Score;
    public Rigidbody rb;

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
            print("space");
            rb.velocity += Vector3.up * 4;
            Score++;
            GameManager.thisManager.UpdateScore(Score);

        }
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name.Equals("Obstacle") || gameObject.transform.position.y >= -45)
        {

            SceneManager.LoadScene(1);
        }
    }
    //public void AddScore(int value)
    //{
    //    Score += value;
    //}
}
