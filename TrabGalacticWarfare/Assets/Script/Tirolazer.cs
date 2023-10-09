using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tirolazer : MonoBehaviour
{
    public float velocidadeLazer;
    public int danodado;
    

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0,0,90);
    }

    // Update is called once per frame
    void Update()
    {
        MovimentoLazer();
    }

    private void MovimentoLazer()
    {
        transform.Translate(Vector3.right * velocidadeLazer * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Inimigo"))
        {
            other.gameObject.GetComponent<Inimigos>().MachucarInim(danodado);
            Destroy(this.gameObject);
        }
    }
    
    
}
