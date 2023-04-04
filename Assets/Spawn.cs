using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    float limite;
    public float tempo;
    public GameObject Inimigo;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // o que você quer fazer aqui
            tempo = tempo += Time.deltaTime;
        if (tempo > 4)
        {
            limite = Random.Range(-6.70f, 6.70f);
            pos = transform.position;
            pos.y = limite;
            Instantiate(Inimigo, pos, Inimigo.transform.rotation);
            tempo = 0;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        // Verifica se o asteroide colidiu com o personagem
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(Inimigo);
            // Termina o jogo
            // GameManager.Instance.EndGame();
        }
    }


    // vector3 pos = transform.position.y;
    //pos = 

    //superior = 6.31
    //inferior = -6.49

}
