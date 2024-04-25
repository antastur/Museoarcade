using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjetoDañadorBueno : MonoBehaviour
{
    private GameManager gameManager;
    public AudioSource fuente;
    public AudioClip impacto;
    public int cantidad;
    

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag== "Enemigo")
        {
            fuente.PlayOneShot(impacto);
            other.gameObject.GetComponent<VideEnemigos>().RestarVida(cantidad);
        }
    }
 
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        cantidad = gameManager.danoaEnem;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
