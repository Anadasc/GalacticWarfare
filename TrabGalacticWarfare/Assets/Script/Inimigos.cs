using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour
{
   public GameObject laserInim;
   public Transform disparoInim;
   public int chanceDeInstanciarPowerup = 50;

   public float velocidadeinimigo;
   public int vidaMInim;
   public float tempomaximoentre;
   public float tempolaser;
   public int vidaAInim;
   public int pontosdados;
   public bool inimAngulo1;
   public bool inimAngulo2;
   public bool inimAtirador;
   public int danoaDar;

   public int escudoMax;
   public int escudoAtual;
   public bool temEscudo;
   public GameObject escudo;
   public GameObject[] powerupPrefabs;

   // Start is called before the first frame update
   void Start()
   {
       vidaAInim = vidaMInim;
       escudoAtual = escudoMax;
   }

   // Update is called once per frame
   void Update()
   {
       MovimetoInimigo();
       if(inimAtirador == true)
       {
           Tirolaser();
       }
  
   }
   private void MovimetoInimigo()
   {
       transform.Translate(Vector3.down* velocidadeinimigo * Time.deltaTime);
   }
   private void Tirolaser()
   {
       tempolaser -= Time.deltaTime;
       if(tempolaser <= 0)
       {
           if (inimAngulo1)
           {
               float angulo = Random.Range(-30f, 30f);
               Quaternion rotacao = Quaternion.Euler(0f,0f,0f+ angulo);
               Instantiate(laserInim, disparoInim.position,rotacao);
               tempolaser = tempomaximoentre;
           }

           if (inimAngulo2)
           {
               float angulo = Random.Range(-60f, 60f);
               Quaternion rotacao = Quaternion.Euler(0f,0f,0f+ angulo);
               Instantiate(laserInim, disparoInim.position,rotacao);
               tempolaser = tempomaximoentre;
           }


       }
   }
   void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<VidaPlayer>().MachucarPlayer(danoaDar);
            Destroy(this.gameObject);
        }
    }

   public void MachucarInim(int danorecebido)
   {
       if (temEscudo)
       {
           escudoAtual--;
           if (escudoAtual <= 0)
           {
               DesativarEscudo();
           }

           return;
       }

       vidaAInim -= danorecebido;
       if (vidaAInim <= 0)
       {
           if (Random.Range(0, 100) < chanceDeInstanciarPowerup)
           {
               // Sorteia um índice aleatório para escolher um dos powerups
               int indiceDoPowerup = Random.Range(0, powerupPrefabs.Length);

               // Instancia o powerup correspondente ao índice sorteado
               Instantiate(powerupPrefabs[indiceDoPowerup], transform.position, Quaternion.identity);
           }

           GameManager.instance.AumentoPontuacao(pontosdados);
           Destroy(this.gameObject);
       }
   }

   public void DesativarEscudo()
   {
       escudo.SetActive(false);
       GetComponent<CapsuleCollider2D>().enabled = false;
       temEscudo = false;
   }
}
