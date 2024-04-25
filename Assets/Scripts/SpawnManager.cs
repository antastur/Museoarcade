using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   
    
    //Lista de enemigos a spawnear
    public GameObject[] listaSpawns;
    //Declaración de variable que determinará el enemigo a spawnear
    private int enemyIndex;
    [SerializeField]
    //valores necesarios para hacer aleatoria la frecuencia del spawn
    private float timeBetweenItems = 15;
    private float randomTimeIncrease = 15;
    private float timeWaitNew;
   
    
    
    //Metodo para spawnear
    void lanzaSpawn()
    {


            //aleatoriedad del objeto spawneado
            enemyIndex = Random.Range(0, listaSpawns.Length);
            //Instanciacion del elegido
            Instantiate(listaSpawns[enemyIndex], transform.position, Quaternion.identity);
            //Generacion de nuevo tiempo de espera aleatorio para siguiente spawn
            timeWaitNew = timeBetweenItems + Random.Range(0, randomTimeIncrease);
           

    }

    private void Awake()
    {
        
        
    }



    // Start is called before the first frame update
    void Start()
    {
        
        timeWaitNew = timeBetweenItems + Random.Range(0, randomTimeIncrease);
        InvokeRepeating("lanzaSpawn", timeWaitNew, timeWaitNew);
     

    }



    // Update is called once per frame
    void Update()
    {
        
            }
        
    
}
