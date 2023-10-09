using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazercontinuo : MonoBehaviour
{
    public int danodado;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {
            other.gameObject.GetComponent<Inimigos>().MachucarInim(danodado);
        }
    }
}

