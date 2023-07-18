using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 2f; // Velocidade do asteroide
    public int testeTiro = 0;
    public PlayerController Nave;
    public int pontos;


    private void Start()
    {

        Nave = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        // Configura a velocidade aleatória do asteroide
        //speed = Random.Range(1f, 4f);
    }

    private void Update()
    {
        // Move o asteroide para a esquerda
        transform.position += Vector3.forward * speed * Time.deltaTime;

        
        if (testeTiro >= 5)
        {
            Nave.pontuacao+= 5;
            Nave.Pontos.text = Nave.pontuacao.ToString();
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se o asteroide colidiu com o personagem
        if (collision.gameObject.CompareTag("tiro"))
        {

            testeTiro++;
            Destroy(collision.gameObject);
           
            Debug.Log("TEste");

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        

        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
            // Termina o jogo
            // GameManager.Instance.EndGame();
        }
    }
}
