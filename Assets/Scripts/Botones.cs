using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botones : MonoBehaviour
{

    //Objeto Game Manager
    private GameManager gameManager;
	//AudioSources
	public AudioSource tema1;
	public AudioSource tema2;
	public AudioSource tema3;
	public AudioSource tema4;
	public AudioSource tema5;

	public AudioListener oidoManager;
	//Botones
	public Button botonInicio, botonJugar, botonOpciones, botonCreditos, botonSalir;
	public Button botonFac, botonNor, botonDif, boton1, boton2, boton3, boton4;
    // Start is called before the first frame update
    
    
    void Start()
    {


		//Busco mi objeto Game Manager
		gameManager = FindObjectOfType<GameManager>();

		
		//Añado al botonInicio la acción a ejecutar al hacer clic (cambiar a la escena Inicio desde el Game Manager)
		if (botonInicio)
		{
			botonInicio.GetComponent<Button>().onClick.AddListener(() => gameManager.cambiarEscena("Inicio"));
		}

		//Añado al botonJugar la acción a ejecutar al hacer clic (cambiar a la escena Jugar desde el Game Manager)
		if (botonJugar)
		{
			botonJugar.GetComponent<Button>().onClick.AddListener(() => gameManager.cambiarEscena("museo2"));
		}

		//Añado al botonOpciones la acción a ejecutar al hacer clic (cambiar a la escena Opciones desde el Game Manager)
		if (botonOpciones)
		{
			botonOpciones.GetComponent<Button>().onClick.AddListener(() => gameManager.cambiarEscena("Opciones"));
		}

		//Añado al botonCreditos la acción a ejecutar al hacer clic (cambiar a la escena Creditos desde el Game Manager)
		if (botonCreditos)
		{
			botonCreditos.GetComponent<Button>().onClick.AddListener(() => gameManager.cambiarEscena("Creditos"));
		}

		//Añado al botonSalir la acción a ejecutar al hacer clic (salir de la aplicación)
		//Este botón no funcionará en el Editor de Unity, pero si al hacr el Build del Juego.
		if (botonSalir)
		{
			botonSalir.GetComponent<Button>().onClick.AddListener(() => Application.Quit());
		}

		if (botonFac)
		{
			botonFac.GetComponent<Button>().onClick.AddListener(() => JugarFacil());
		}

		if (botonNor)
		{
			botonNor.GetComponent<Button>().onClick.AddListener(() => JugarNormal());
		}

		if (botonDif)
		{
			botonDif.GetComponent<Button>().onClick.AddListener(() => JugarDificil());
		}

		if (boton1)
		{
			boton1.GetComponent<Button>().onClick.AddListener(() => TocarTema1());
		}

		if (boton2)
		{
			boton2.GetComponent<Button>().onClick.AddListener(() => TocarTema2());
		}

		if (boton3)
		{
			boton3.GetComponent<Button>().onClick.AddListener(() => TocarTema3());
		}

		if (boton4)
		{
			boton4.GetComponent<Button>().onClick.AddListener(() => TocarTema4());
		}

	}

    private void Update()
    {
		
	}

	//Metodo que establece variables del gameManager para hacer el juego facil 
	void JugarFacil()
    {
		
		gameManager.danoaEnem = 50;
		gameManager.danodeEnem = 5;
	}

	//Metodo que establece variables del gameManager para hacer el juego normal 
	void JugarNormal()
	{
		
		gameManager.danoaEnem = 50;
		gameManager.danodeEnem = 10;
	}

	//Metodo que establece variables del gameManager para hacer el juego dificil 
	void JugarDificil()
	{
		
		gameManager.danoaEnem = 25;
		gameManager.danodeEnem = 20;
	}

	//Metodos para elegir cancion


	void TocarTema1()
    {
		gameManager.loading.Stop();
		gameManager.loading.clip = tema1.clip;
		gameManager.loading.Play();
    }


	void TocarTema2()
	{
		gameManager.loading.Stop();
		gameManager.loading.clip = tema2.clip;
		gameManager.loading.Play();
	}


	void TocarTema3()
	{
		gameManager.loading.Stop();
		gameManager.loading.clip = tema3.clip;
		
		gameManager.loading.Play();
	}


	void TocarTema4()
	{
		gameManager.loading.Stop();
		gameManager.loading.clip = tema4.clip;
		gameManager.loading.Play();
	}


}
