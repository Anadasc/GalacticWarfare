using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody2D rig2d;
    public GameObject tiroPlayer;
    public GameObject EscudoPlayer;

    public GameObject lazerContinuo;
    public Transform disparoUnico;

    public float Esquerda, Direita, Cima, Baixo;
    public float velocidadePlayer;
    public bool temduplo;
    
    public GameObject tiroPlayer2;
    public int balas;
    public bool isShooting;
    public int municao;
    public int tiros;
    public GameObject superTiro;
    public Text balastexto;
    public Text lasertexto;
    
    private Vector2 teclasU;

    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
        temduplo = false;
        balas = 50;
        municao = 100;
        tiros = 1;
        lazerContinuo.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentoPlayer();
        Atirar();
        LimiteScene();
        tiroselecao();
        updatemunicao();
    }
    
    private void MovimentoPlayer()
    {
        teclasU = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rig2d.velocity = teclasU.normalized * velocidadePlayer;
    }
    private void Atirar()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (tiros == 1 && !temduplo)
            {
                Instantiate(tiroPlayer, disparoUnico.position, disparoUnico.rotation);
                
            }
            else if (tiros == 2 && balas > 0 && !temduplo)
            {
                Instantiate(tiroPlayer2, disparoUnico.position, disparoUnico.rotation);
                balas -= 1;
                updatebalas();
                
            }
            else if (tiros == 3 && municao > 0 && !temduplo)
            {
                isShooting = true; // Comece o tiro contínuo
                lazerContinuo.SetActive(true);
                StartCoroutine(Atirarlaser());
                
            }
        }

        // Verifique se o botão Fire1 foi solto e pare o tiro contínuo, se aplicável
        if (Input.GetButtonUp("Fire1"))
        {
            isShooting = false; // Pare o tiro contínuo
            lazerContinuo.SetActive(false);
        }
    }

    private IEnumerator Atirarlaser()
    {
        while (isShooting && municao > 0)
        {
            municao--;
            yield return new WaitForSeconds(0.1f);
        }

        if (municao <= 0)
        {
            StopCoroutine(Atirarlaser());
        }
    }

    
    private void LimiteScene()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, Esquerda, Direita),
        Mathf.Clamp(transform.position.y, Baixo, Cima),transform.position.z);
    }
    public void tiroselecao()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            tiros += 1;
            if (tiros > 3)
            {
                tiros = 1;
            }
        }
        if (balas <= 0)
        {
            balas = 0;
        }
        if (balas >= 100)
        {
            balas = 100;
        }
        
    }

    public void SuperTiro()
    {
        Instantiate(superTiro, disparoUnico.position, disparoUnico.rotation);
        Instantiate(superTiro, disparoUnico.position, disparoUnico.rotation);
    }

    public void updatebalas()
    {
        balastexto.text = balas.ToString();
    }
    public void updatemunicao()
    {
        lasertexto.text = municao.ToString();
    }
    
}
