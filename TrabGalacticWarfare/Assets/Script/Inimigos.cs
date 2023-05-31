using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour
{
    public GameObject laserInim;
    public Transform disparoInim;

    public float velocidadeinimigo;
    public int vidaMInim;
    public float tempomaximoentre;
    public float tempolaser;
    public int vidaAInim;
    public int pontosdados;

    public bool inimAtirador;

    // Start is called before the first frame update
    void Start()
    {
        vidaAInim = vidaMInim;
    }

    // Update is called once per frame
    void Update()
    {
        MovimetoInimigo();
        if(inimAtirador == true)
        {
            Tirolaser();
        }
    
    }
    private void MovimetoInimigo()
    {
        transform.Translate(Vector3.down * velocidadeinimigo * Time.deltaTime);
    } 
    private void Tirolaser()
    {
        tempolaser -= Time.deltaTime;
        if(tempolaser <= 0)
        {
            Instantiate(laserInim, disparoInim.position, Quaternion.Euler(0f, 0f, 0f));
            tempolaser = tempomaximoentre;
        }
    }
    public void MachucarInim(int danorecebido)
    {
        vidaAInim -= danorecebido;
        if(vidaAInim <= 0)
        {
            GameManager.instance.AumentoPontuacao(pontosdados);
            Destroy(this.gameObject);
        }
    }
}
