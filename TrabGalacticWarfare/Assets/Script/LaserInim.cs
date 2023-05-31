using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserInim : MonoBehaviour
{
    public float velocidadeLaser;
    public int danoaDar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarLaser();
    }
    private void MovimentarLaser()
    {
        transform.Translate(Vector3.left * velocidadeLaser * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<VidaPlayer>().MachucarPlayer(danoaDar);
            Destroy(this.gameObject);
        }
    }

}
