using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float flapForce = 10f;
    public float maxVelocity = 5f;
   public GameObject MenuPerdeu;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        // Verifica se a barra de espa�o foi pressionada para fazer a nave pular
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Adiciona for�a a nave para faz�-lo voar para cima
            rb.AddForce(Vector3.up * flapForce, ForceMode.Impulse);
        }

        // Limita a velocidade da nave para que ele n�o pule muito r�pido
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
            
            //colocar pontua��o aqui
           
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
    }
}