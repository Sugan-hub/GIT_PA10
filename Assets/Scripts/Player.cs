using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager GM;
    private Animation thisAnimation;
    private Vector3 Direction;
    public float gravity = -9.8f;
    public float strength = 5f;

    public float minY = -4f;
    public float maxY = 4f;
    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        gameObject.transform.position = new Vector3(0, Mathf.Clamp(transform.position.y, minY, maxY), 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            Direction = Vector3.up * strength;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) 
            {
                Direction = Vector3.up * strength;
            }
        }
        Direction.y += gravity * Time.deltaTime;
        transform.position += Direction * Time.deltaTime;
            
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            GM.GameOver();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            GM.UpdateScore(1);
        }
    }
}
