﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script manages the behavior of individual obstacle
public class Obstacle : MonoBehaviour
{
    [SerializeField] private float Speed = 3;
    public Vector3 upward;
    public Vector3 downward;
    public bool hasHit = false;
    public int Score;

    void Start()
    {
    }
    void Update()
    {
        if (transform.position.x <= -8)
            Destroy(gameObject);
        else
            transform.Translate(Vector3.right * Time.deltaTime * -Speed);



    }
}
