using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PuntuacionFinal : MonoBehaviour
{
    //Objeto Game Manager
    private GameManager gameManager;
    public Text puntuacionFinal;
    public AudioSource temaini;
   
    // Start is called before the first frame update
    void Start()
    {   
        
        gameManager = FindObjectOfType<GameManager>();
        puntuacionFinal.text = gameManager.contador.ToString();
        gameManager.contador = 0;
        gameManager.lifePlayer = 100;
        //gameManager.loading = temaini;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
