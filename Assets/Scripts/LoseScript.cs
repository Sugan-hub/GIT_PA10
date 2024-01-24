using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OncollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "obstacle")
        {
            SceneManager.LoadScene("LoseScene");


            
        }
    }






}
