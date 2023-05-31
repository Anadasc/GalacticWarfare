using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rig2d;
    public GameObject tiroPlayer;
    public Transform disparoUnico;

    public float velocidadePlayer;
    public bool temduplo;


    private Vector2 teclasU;

    // Start is called before the first frame update
    void Start()
    {
        temduplo = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentoPlayer();
        Atirar();
    }
    private void MovimentoPlayer()
    {
        teclasU = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rig2d.velocity = teclasU.normalized * velocidadePlayer;
    }
    private void Atirar()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(temduplo == false) 
            {
                Instantiate(tiroPlayer, disparoUnico.position, disparoUnico.rotation);

            }
        }
    }
}
