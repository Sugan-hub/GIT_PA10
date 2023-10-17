using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;

    public Rigidbody rb;
    public float force;
    

    public float minY = -3.5f;
    public float maxY = 3.5f;

    bool triggeredPoints;

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
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }

        Vector3 currentPosition = transform.position;
        currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);
        transform.position = currentPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") && !triggeredPoints)
        {
            triggeredPoints = true;
            GameManager.thisManager.UpdateScore(1);
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle") && triggeredPoints)
        {
            triggeredPoints = false;
        }
    }

}
