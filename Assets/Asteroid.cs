using UnityEngine;


public class Asteroid : MonoBehaviour
{
    public float speed = 2f; // Velocidade do asteroide
    public int testeTiro = 0;
    public GameObject explosaoPrefab;

    private void Start()
    {
        // Configura a velocidade aleatória do asteroide
        //speed = Random.Range(1f, 4f);
    }

    private void Update()
    {
        // Move o asteroide para a esquerda
        transform.position += Vector3.forward * speed * Time.deltaTime;

        
        if (testeTiro >= 5)
        {
            GameObject explosao = GameObject.Instantiate(explosaoPrefab);
            explosao.transform.position = this.gameObject.transform.position;

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
