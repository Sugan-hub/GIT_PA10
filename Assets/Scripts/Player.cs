using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public float Speed;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = transform.up * Speed * Time.deltaTime;
        }
            thisAnimation.Play();
    }
}
