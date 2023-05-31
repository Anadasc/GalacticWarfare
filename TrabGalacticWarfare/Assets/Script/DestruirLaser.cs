using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirLaser : MonoBehaviour
{
    public float tempoDuracao;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, tempoDuracao);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
