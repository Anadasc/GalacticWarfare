using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    public Text textPontuacaoA;
    public int pontuacaoAtual;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        pontuacaoAtual = 0;
        textPontuacaoA.text = "PONTOS: "+ pontuacaoAtual;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AumentoPontuacao(int pontosganhos)
    {
        pontuacaoAtual += pontosganhos;
        textPontuacaoA.text = "PONTOS: "+ pontuacaoAtual;
    }
}

