using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    int force = 200;
    public GameObject obstacle;
    public Text scoretext;
    public float speed;

    private Animation thisAnimation;

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
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, force, 0));
        }
            
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            SceneManager.LoadScene("LoseScene");
        }

        if (collision.gameObject.tag == "obstacle")
        {
            score++;
            Scoretext.text = "Score : " + score;
        }



}
