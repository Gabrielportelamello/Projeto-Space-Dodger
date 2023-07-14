using UnityEngine;


public class NaveInimiga : MonoBehaviour
{
    public float speed = 2f; // Velocidade do asteroide
    public int testeTiro = 0;
    public GameObject TiroInimigo;
    public float tempo;
    Vector3 pos;
    private AudioSource audioSource;

    private void Start()
    {
        // Configura a velocidade aleatória do asteroide
        //speed = Random.Range(1f, 4f);
        audioSource = GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        // Move o asteroide para a esquerda
        tempo = tempo += Time.deltaTime;
        pos = transform.position;
        pos.x = 7;
       
        if (tempo > 2)
        {
            audioSource.Play();
            Instantiate(TiroInimigo, pos, TiroInimigo.transform.rotation);
            tempo = 0;
        } 


        transform.position += Vector3.forward * speed * Time.deltaTime;


        if (testeTiro >= 2)
        {
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
