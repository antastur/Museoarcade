using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaInicio : MonoBehaviour
{
    //Atributo para musica de fondo
    public AudioSource musicaInicio;
    //Atributo para usar el GameManager;
    private GameManager gameManager;


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
