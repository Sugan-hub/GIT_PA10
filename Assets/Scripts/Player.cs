using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody PlayerRigibody;
    public float jumpForce;
    private Transform player;
    
    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        PlayerRigibody = GetComponent<Rigidbody>();
        player = transform;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            PlayerRigibody.velocity = Vector3.zero;
            PlayerRigibody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        clamp();

        if (transform.position.y < -3.4f)
        {
            GameManager.thisManager.GameOver();
            SceneManager.LoadScene(1);
            //Debug.Log("ok");
        }
    }

    void clamp()
    {
        float clampY = Mathf.Clamp(player.position.y, -3.5f, 3.5f);
        player.position = new Vector3(player.position.x, clampY, player.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag== "Obstacle")
        {
            GameManager.thisManager.GameOver();
            SceneManager.LoadScene(1);
            //Debug.Log("lose");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== "Avoid")
        {
            int point = 1;
            GameManager.thisManager.UpdateScore(point);
        }
    }
}
