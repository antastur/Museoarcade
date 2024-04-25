using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVida : MonoBehaviour
{
    //Objeto Game Manager
    private GameManager gameManager;
    //Para emitir sonidos
    public AudioSource fuente;
    public AudioClip gritoPlayer;
    
    //variables para que el daño no sea continuo en caso de entrar en un trigger enemigo
    public bool sinDaño=false;
    public float tiempoSinDaño;
    public float tiempoFrenado = 0.2f;
    private Animator animator;
   
    //Metodo que actualiza la vida del player al recibir daño
    public void RestarVida()
    {

        if(!sinDaño && gameManager.lifePlayer > 0) 
        {
            gameManager.lifePlayer -= gameManager.danodeEnem;
            StartCoroutine(Invulnerabilidad());
            StartCoroutine(FrenarVelocidad());
                 if (gameManager.lifePlayer <= 0)
            {
                fuente.PlayOneShot(gritoPlayer);
                Cursor.lockState = CursorLockMode.None;
                animator.SetBool("Is_Dead", true);
                //StartCoroutine("Esperar");
                gameManager.isGameOver = true;
                
               
            }
        }
        
    }

    //Metodo para comprobar si player se cae por una puerta al vacío
    void ComprobarCaida()
    {   

        //Si la posicion del player está 3 m por debajo del suelo
        if(gameObject.transform.position.y < -3f)
        {
            fuente.PlayOneShot(gritoPlayer);
            //Se desbloquea puntero raton
            Cursor.lockState = CursorLockMode.None;
            animator.SetBool("Is_Dead", true);

            //StartCoroutine("Esperar");
            gameManager.isGameOver = true;
        }
    }


    //Metodo que hace esperar
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(10);
    }
   
    //Metodo que proporciona un tiempo durante elque el daño no es continuo
    IEnumerator Invulnerabilidad()
    {
        sinDaño = true;
        yield return new WaitForSeconds(tiempoSinDaño);
        sinDaño = false;

    }

    //Metodo que Frena la velocidad un tiempo determinado al recibir daño
    IEnumerator FrenarVelocidad()
    {
        var velocidadActual = GetComponent<Control1Persona>().vel;
        GetComponent<Control1Persona>().vel = 0;
        yield return new WaitForSeconds(tiempoFrenado);
        GetComponent<Control1Persona>().vel = velocidadActual;
    }


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        InvokeRepeating("ComprobarCaida", 3, 3);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
