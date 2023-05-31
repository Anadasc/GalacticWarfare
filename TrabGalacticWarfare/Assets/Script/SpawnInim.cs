using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInim : MonoBehaviour
{
    public GameObject[] objetosSpawnados;
    public Transform[] pontosDeSpawn;
    public float tempomentrespawn;
    public float tempoAtualSpawn;

    // Start is called before the first frame update
    void Start()
    {
        tempoAtualSpawn = tempomentrespawn;
    }

    // Update is called once per frame
    void Update()
    {
        tempoAtualSpawn -= Time.deltaTime;
        if(tempoAtualSpawn <= 0)
        {
            SpawnarInim();
        }
    }
    private void SpawnarInim()
    {
        int objetoAleatorio = Random.Range(0,objetosSpawnados.Length);
        int pontoAleatorio = Random.Range(0, pontosDeSpawn.Length);

        Instantiate(objetosSpawnados[objetoAleatorio], pontosDeSpawn[pontoAleatorio].position, Quaternion.Euler(0f, 0f, -90f));
        tempoAtualSpawn = tempomentrespawn;
    }
}
