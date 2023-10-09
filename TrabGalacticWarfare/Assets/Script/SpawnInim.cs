using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInim : MonoBehaviour
{
    public GameObject[] objetosSpawnados;
    public Transform[] pontosDeSpawn;
    public float tempomentrespawn;
    public float tempoAtualSpawn;
    public float tempoEspera = 15f;
    public bool canStart = false;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Fase2", tempoEspera);
        tempoAtualSpawn = tempomentrespawn;
    }

    // Update is called once per frame
    void Update()
    {
        if(canStart)
        {
            tempoAtualSpawn -= Time.deltaTime;
            if(tempoAtualSpawn <= 0)
            {
                SpawnarInim();
            }
        }
    }
    private void Fase2()
    {
        canStart = true;
    }

    private void SpawnarInim()
    {
        int objetoAleatorio = Random.Range(0,objetosSpawnados.Length);
        int pontoAleatorio = Random.Range(0, pontosDeSpawn.Length);

        Instantiate(objetosSpawnados[objetoAleatorio], pontosDeSpawn[pontoAleatorio].position, Quaternion.Euler(0f, 0f, -90f));
        tempoAtualSpawn = tempomentrespawn;
    }
    
}