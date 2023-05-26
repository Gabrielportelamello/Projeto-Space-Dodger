using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float tempo;
    public float flapForce = 10f;
    public float maxVelocity = 5f;
    public GameObject MenuPerdeu;
    public TextMeshProUGUI Pontos;
    public int pontuacao;
    public Rigidbody rb;
    public GameObject Tiro;
    Vector3 pos;
    public bool tiroteste=true;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        if(tiroteste == false)
        {
            tempo = tempo += Time.deltaTime;
            if (tempo > 1)
            {

                tempo = 0;
                tiroteste = true;
            }
        }

            // Verifica se a barra de espaço foi pressionada para fazer a nave pular
            if (Input.GetKeyDown(KeyCode.Space))
        {
            // Adiciona força a nave para fazê-lo voar para cima
            rb.AddForce(Vector3.up * flapForce, ForceMode.Impulse);

            
            
        }

        // Limita a velocidade da nave para que ele não pule muito rápido
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }

        

        // Inclina a nave para a esquerda ou direita com base no movimento do mouse ou teclado
        //float tiltAngle = 30f;
        //float horizontalInput = Input.GetAxis("Horizontal");
        //Quaternion targetRotation = Quaternion.Euler(0f, 0f, -horizontalInput * tiltAngle);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
    }


    private void OnTriggerEnter(Collider collision)
    {
        // Verifica se o asteroide colidiu com o personagem
        if (collision.gameObject.CompareTag("rock"))
        {
            pontuacao++;
            Pontos.text = pontuacao.ToString();
            Debug.Log(Pontos);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se o asteroide colidiu com o personagem
        if (collision.gameObject.CompareTag("rock"))
        {

            Time.timeScale = 0;
            MenuPerdeu.SetActive(true);
            Debug.Log("TEste");

        }

        if (collision.gameObject.CompareTag("tiroInimigo"))
        {

            Time.timeScale = 0;
            MenuPerdeu.SetActive(true);
            Debug.Log("TEste");

        }


    }

    public void Atirar() {

        if (tiroteste)
        {
            pos = transform.position;
            pos.x = 7;
            pos.z = 10;

            Instantiate(Tiro, pos, Tiro.transform.rotation);

            tiroteste = false;
        }
    }

    public void Reiniciar() 
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
        MenuPerdeu.SetActive(false);
    }
}