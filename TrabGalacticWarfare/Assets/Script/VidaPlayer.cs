using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaPlayer : MonoBehaviour
{
    public int vidaMaximaPlayer;
    public Slider barradevida;
    public int vidaAtualPlayer;
    public bool temEscudo;
    public int vidas;
    public Text vidasTexto;

    public GameObject EscudoPlayer;

    public int vidaAtualEscudo;

    public int vidaMaximaEscudo;
    // Start is called before the first frame update
    void Start()
    {
        vidaAtualPlayer = vidaMaximaPlayer;
        barradevida.maxValue = vidaMaximaPlayer;
        barradevida.value = vidaAtualPlayer;
        vidas = 6;
        vidasTexto.text = "VidasRestantes: "+ vidas;
        
        EscudoPlayer.SetActive(false);
        temEscudo = false;

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void MachucarPlayer(int danoaReceber)
    {
        if(temEscudo == false)
        {
            vidaAtualPlayer -= danoaReceber;
            barradevida.value = vidaAtualPlayer;
            if(vidaAtualPlayer <= 0)
            {
                vidas--;
                if(vidas <= 0)
                {
                    SceneManager.LoadScene("SampleScene");
                    Debug.Log("Game Over");
                }
                else 
                {
                    vidaAtualPlayer = vidaMaximaPlayer;
                    barradevida.value = vidaAtualPlayer;
                    Updatevidastexto();
                    Debug.Log("Perdeu um vida. Vidas Restantes: " + vidas);
                }

            }
        }
    }
    public void Updatevidastexto()
    {
        vidasTexto.text = "VidasRestantes: " + vidas;
    }
    
    public void ativarEscudo()
    {
        vidaAtualEscudo = vidaMaximaPlayer;
        temEscudo = true;
        EscudoPlayer.SetActive(true);
    }
}
