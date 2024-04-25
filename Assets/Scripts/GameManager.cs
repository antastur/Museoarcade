using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    

    //Atributo puntos del player
    public int contador=0;
    
    //Atributo vida de jugador
    public int lifePlayer=100;

    //Atributo de fin de partida
    public bool isGameOver;

    //Atributos dificultad facil
    public int  danoaEnem=50;//objetodanadorbueno cantidad
    public int danodeEnem=5;//objetodanador cantidad

    //Atributos gestion musicas de fondo
    public AudioSource loading;
    


    // Start is called before the first frame update
    void Start()
    {

        //Busco el objeto llamado GameManager
        GameObject gameManager = GameObject.Find("GameManager");
        
        loading.Play();
        //
        //Le indico que no se destruya al cargar otra escena 
        DontDestroyOnLoad(gameManager);

        InvokeRepeating("ComprobarGameOver", 3, 1.5f);
       

        //Cargo la escena de inicio
        SceneManager.LoadScene("Inicio");

       
    }


    private void Update()
    {
    }

    //Metodo para cambiar la escena
    public void cambiarEscena(string nombreEscena)
    {
         SceneManager.LoadScene(nombreEscena);
    }


    //Metodo para comprobar el Gameover
    void ComprobarGameOver()
    {
        if (isGameOver == true)
        {
            cambiarEscena("GameOver");
            //Para que al volver a jugar la variable isGameover sea falsa
            isGameOver = false;
        }
   
   

    }
}