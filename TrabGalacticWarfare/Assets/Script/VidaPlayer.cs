using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    public int vidaMaximaPlayer;
    public Slider barradevida;
    public int vidaAtualPlayer;
    public bool temEscudo;
    
    // Start is called before the first frame update
    void Start()
    {
        vidaAtualPlayer = vidaMaximaPlayer;
        barradevida.maxValue = vidaMaximaPlayer;
        barradevida.value = vidaAtualPlayer;
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
                Debug.Log("Game Over");
            }
        }
    }
}
