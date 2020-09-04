using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("A"))
        {

            Application.LoadLevel("dickaiship");
        }

        if (Input.GetButtonDown("X"))
        {
            Application.LoadLevel("credits");
        }

        if (Input.GetButtonDown("B"))
        {
            Application.LoadLevel("title");
        }

        if (Input.GetButtonDown("Y"))
        {
            Application.Quit();
        }


    }
}
