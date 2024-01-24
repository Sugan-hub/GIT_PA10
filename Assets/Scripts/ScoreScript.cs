using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    int score;
    public Text Scoretext;

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
            score++;
            Scoretext.text = "Score : " + score;


            Destroy(collision.gameObject); 
        }
    }
}
