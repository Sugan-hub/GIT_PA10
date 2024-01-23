using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    private float _velocity = 200f;
    private Rigidbody _rb;

    private int Score;

    public Text ScoreText;

    private Animation thisAnimation;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.y >= 3)
        {
            transform.position = new Vector3(transform.position.x, 3, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            _rb.velocity = Vector2.zero;
            _rb.AddForce(Vector2.up * _velocity);
        }

        if (transform.position.y <= -4)
        {
            SceneManager.LoadScene("GameLose");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Environment")
        {
            SceneManager.LoadScene("GameLose");
        }

        if (other.gameObject.tag == "Score")
        {
            Score++;
            ScoreText.text = ("SCORE : ") + Score.ToString();
        }
    }
}
