using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Control1Persona : MonoBehaviour
{
    //Para usar fisica con Player
    private Rigidbody rb;

    
    //Para dar funcionalidad a camara en 1 persona
    public Transform cam;
    public Camera cam1;
    public Camera cam2;
    Vector2 inputMov;
    Vector2 inputRot;
    public float sensibilidadRaton = 5f;
    float vistaY;

    //Velocidades del Player
    public float vel = 10f;
    public float velCamina=12f;
    public float velCorre = 25f;

    //Atributo de intensidad del salto
    public float fuerzaSalto = 350f;

    //Atributos para la funcion de disparo
    public GameObject bala;
    public Transform SpawnBalas;
    public float velocidadBala;
    public float proximoDisparo;

    //Atributos de paneles informacion
    public Text puntuacion;
    public Text vida;
    
    //Para la animacion del personaje
    private Animator animator;

    //Para emitir sonidos
    public AudioSource fuente;
    public AudioClip disparo;
    public AudioClip salto;
    public AudioClip aplauso;
    public AudioClip abucheo;
    //para recibir pistas
    public Text[]  textoRecibe;
    private int contador=0;

    //Para obtencion de vida y puntos del GameManager
    private GameManager gameManager;
    

    // Start is called before the first frame update
    void Start()
    {
        //Se obtienen el gameManager activo
        gameManager = FindObjectOfType<GameManager>();
        //Se obtienen los distintos componentes que usaremos del player
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        //y del gameManager
        gameManager.loading = GetComponent<AudioSource>();
        gameManager.loading.Play();
        fuente = GetComponent<AudioSource>();
        //se bloquea el puntero raton
        Cursor.lockState = CursorLockMode.Locked;
     }

    public void OnTriggerEnter(Collider other)
    {
       
        //Se activa el Text si se entra en el trigger del item Pista
        if (other.CompareTag("Pista"))
        {
            textoRecibe[contador].gameObject.SetActive(true);

        }
    }




    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Cuadro"))
        {   
            //Si el texto activado contiene el nombre del cuadro y además se apreta el disparo
            if (Input.GetButtonDown("Fire1")) {
                if (textoRecibe[contador].text.Contains(other.gameObject.name))
                {
                    //Si se acierta se emite aplauso,se suman 20 puntos,se destruye el objeto Text y se incrementa variable
                    //contador para pasar al siguiente Text la próxima vez que se atraviese el item
                    fuente.PlayOneShot(aplauso);
                    Destroy(textoRecibe[contador]);
                    gameManager.contador = gameManager.contador + 20;
                    contador = contador + 1;
                }
                else
                {   
                    //Si falla emite abucheo y resta 10 puntos o deja en 0
                    fuente.PlayOneShot(abucheo);
                    if (gameManager.contador >= 10) {
                        gameManager.contador = gameManager.contador - 10;
                    }
                    else
                    {
                        gameManager.contador = 0;
                    }
                    
                }


            }

        }
    }


    // Update is called once per frame
    void Update()
    {

        //Disparo
        if (Input.GetButtonDown("Fire1"))
        {
            //Instancio un nuevo disparo en esa posición y con esa rotación
            animator.SetTrigger("Throwing");
            //Sonido de disparo
            fuente.PlayOneShot(disparo);
            //Instanciacion de la bala
            GameObject nuevaBala = Instantiate(bala, SpawnBalas.position, SpawnBalas.rotation);
            nuevaBala.GetComponent<Rigidbody>().AddForce(SpawnBalas.forward * velocidadBala * Time.deltaTime, ForceMode.Impulse);
            //Se destruye la bala en 1 segundo
            Destroy(nuevaBala, 1.0f);

        }


        //Condiciones para saltar
        if (Input.GetButtonDown("Jump") && isSuelo())
        {
            fuente.PlayOneShot(salto);
             rb.AddForce(transform.up * fuerzaSalto, ForceMode.Impulse);
        }

        //Cambio de camara

        if (Input.GetKeyDown("1"))
         {
             cam1.enabled = true;
             cam2.enabled = false;
         }

         if (Input.GetKeyDown("2"))
         {
             cam1.enabled = false;
             cam2.enabled = true;
         }


      //Actualizacion del canvas vida y puntuacion
        puntuacion.text = " " + gameManager.contador.ToString();
        vida.text = " " + gameManager.lifePlayer.ToString();

    }

    private void FixedUpdate()
    {   

        //Captura movimiento player
        //Leemos el input
        inputMov.x = Input.GetAxis("Horizontal");
        inputMov.y = Input.GetAxis("Vertical");
        //Establecemos parametro de animacion
        animator.SetFloat("MoveX", inputMov.x);
        animator.SetFloat("MoveY", inputMov.y);

        inputRot.x = Input.GetAxis("Mouse X") * sensibilidadRaton;
        inputRot.y = Input.GetAxis("Mouse Y");

        //usamos ese input para movernos y girar
        vel = Input.GetKey(KeyCode.LeftShift) ? velCorre : velCamina;
        //Animacion de andar o correr
        if (vel == velCorre)
        {
            
            animator.SetBool("Is_Running",true);
        }
        else
        {
            animator.SetBool("Is_Running", false);
        }

        rb.velocity = transform.forward * vel * inputMov.y //movernos hacia delante y atrás
                       + transform.right * vel * inputMov.x //movernos izda y dcha
                       + new Vector3(0, rb.velocity.y, 0);  //dejar mov eje y en manos de la fisica

        //Movimiento camara 1 persona
        transform.localRotation *= Quaternion.Euler(0, inputRot.x * sensibilidadRaton, 0);

        vistaY -= inputRot.y;
        vistaY = Mathf.Clamp(vistaY, -90f, 90f);
        cam.localRotation = Quaternion.Euler(vistaY * sensibilidadRaton, 0f, 0f);

    }



    //Metodo para comprobar si el jugador está en el suelo antes de saltar (para que no vuele)
    private bool isSuelo()
    {

        //Genero el array de colisiones de la esfera/jugador pasando su centro y su radio
        Collider[] colisiones = Physics.OverlapSphere(transform.position, 1f);
        //Recorro ese array y si está colisionando con el suelo devuelvo true
        foreach (Collider colision in colisiones)
        {
            if (colision.tag == "Suelo")
            {
                return true;
            }
        }
        return false;

    }



}
