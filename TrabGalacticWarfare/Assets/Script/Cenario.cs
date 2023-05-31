using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cenario : MonoBehaviour
{
    public float velocidadeCena;

    // Update is called once per frame
    void Update()
    {
        MovimentoCena();
    }
    private void MovimentoCena()
    {
        Vector2 deslocamentoCena = new Vector2(Time.time * velocidadeCena, 0f);
        GetComponent<Renderer>().material.mainTextureOffset = deslocamentoCena;
        
    }
}
