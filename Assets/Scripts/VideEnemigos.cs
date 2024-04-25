using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideEnemigos : MonoBehaviour
{   

    private GameObject enemigo;
    public int vida = 100;
    private GameManager gameManager;
    public AudioSource fuente;
    public AudioClip gritoEnemy;


    public void RestarVida(int cantidad)
    {
        if (vida > 0)
        {
            vida -= cantidad;
            if (vida <= 0)
            {
                fuente.PlayOneShot(gritoEnemy);
                Destroy(gameObject, .5f);
                gameManager.contador = gameManager.contador + 1;
            }
        
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}