using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public Rigidbody rb;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rb.AddForce(0,175, 0);
            thisAnimation.Play();
        }   
       
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("LoseScene");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
