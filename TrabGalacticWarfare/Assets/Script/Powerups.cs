using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    
    public bool escudo;

    public bool supertiro;

    public bool balas;

    public bool lcontinuo;

    public float tempodevida;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, tempodevida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (escudo)
            {
                other.gameObject.GetComponent<VidaPlayer>().ativarEscudo();
            }

            if (supertiro)
            {
                other.gameObject.GetComponent<Player>().SuperTiro();
            }

            if (balas)
            {
                other.gameObject.GetComponent<Player>().balas = 50;
                other.gameObject.GetComponent<Player>().updatebalas();
            }
            
            if (lcontinuo)
            {
                other.gameObject.GetComponent<Player>().municao = 100;
                other.gameObject.GetComponent<Player>().updatemunicao();
            }
            Destroy(this.gameObject);
            
            
        }
        
    }
}
