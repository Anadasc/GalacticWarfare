
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    public Text textPontuacaoA;
    public int pontuacaoAtual;

    void Awake()
    {
        if (instance==null)
        {
            instance = this;
            DontDestroyOnLoad(this.GameObject());
        }
        else
        {
            Destroy(this.GameObject());
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Menu");
        pontuacaoAtual = 0;
        textPontuacaoA.text = "PONTOS: "+ pontuacaoAtual;
    }
    public void AumentoPontuacao(int pontosganhos)
    {
        pontuacaoAtual += pontosganhos;
        textPontuacaoA.text = "PONTOS: "+ pontuacaoAtual;
    }

    public void chamar()
    {
        SceneManager.LoadScene("GUI");
        SceneManager.LoadScene("Fase1", LoadSceneMode.Additive);
    }
}

