using UnityEngine;


public class Asteroid : MonoBehaviour
{
    public float speed = 2f; // Velocidade do asteroide
    

    private void Start()
    {
        // Configura a velocidade aleatória do asteroide
        //speed = Random.Range(1f, 4f);
    }

    private void Update()
    {
        // Move o asteroide para a esquerda
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider collision)
    {
        // Verifica se o asteroide colidiu com o personagem
        if (collision.gameObject.CompareTag("Player"))
        {
            
            // Termina o jogo
            
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
            // Termina o jogo
            // GameManager.Instance.EndGame();
        }
    }
}
