using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    float limite;
    public float tempo;
    public GameObject[] Inimigo;
    public PlayerController Nave;
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
            if (Nave.pontuacao < 2)
            {
                Instantiate(Inimigo[0], pos, Inimigo[0].transform.rotation);
            }
            else 
            {
                int aleatorio = Random.Range(0, 2);
                print(aleatorio);
                Instantiate(Inimigo[aleatorio], pos, Inimigo[aleatorio].transform.rotation);
            }
            tempo = 0;
        }
    }

}
