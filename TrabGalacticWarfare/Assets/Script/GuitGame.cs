using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitGame : MonoBehaviour
{


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}

