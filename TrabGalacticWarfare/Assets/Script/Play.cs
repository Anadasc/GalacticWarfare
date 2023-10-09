using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void OnLeadScene(string scene)
    {
        GameManager.instance.chamar();
    }

    public void Quit()
    {
        Application.Quit();
    }
}

