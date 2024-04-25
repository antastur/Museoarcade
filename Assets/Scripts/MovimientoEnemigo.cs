using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoEnemigo : MonoBehaviour

{

    public NavMeshAgent Agent;
    Vector3 NewPos;
    private Transform perseguido;
   
   
    public int moveMaxSpeed ;
    public int moveMinSpeed ;
    public float velocidadPersecucion;
    private float distancia;
    public float distanciaSeguir;

    //Metodo que genera movimiento aleatorio de los enemigos
    void MovEnemy()
    {
        
        NewPos = transform.position + new Vector3(Random.onUnitSphere.x * 100, 0f, Random.onUnitSphere.z * 100);
        Agent.destination = NewPos;
        
        Agent.speed=Random.Range(moveMinSpeed,moveMinSpeed);
        
    }


    //Metodo que dada una cierta distancia al player le sigue
    void perseguirPlayer(){

        distancia = Vector3.Distance(perseguido.transform.position, transform.position);
        if (distancia < distanciaSeguir)
        {

            Agent.destination = perseguido.position;
            Agent.speed = velocidadPersecucion;

        }
    }

   

    


void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }


    
    // Start is called before the first frame update
    void Start()
    {
        perseguido = GameObject.FindWithTag("Player").transform; 
        InvokeRepeating("MovEnemy",0,Random.Range(3,10));
        
    }
        // Update is called once per frame
        void Update()
            
        {
        perseguirPlayer();

    }
    

    }