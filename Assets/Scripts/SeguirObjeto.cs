using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirObjeto : MonoBehaviour
{
    //Referencia al objeto a seguir (jugador)
    public Transform perseguidor;
    public Transform perseguido;
    public float distanciaSeguir;
    public float velocidad;
    public float velocidadRotacion;

    private void Awake()
    {
        perseguidor = transform;
    }




    // Start is called before the first frame update
    void Start()
    {
        perseguido = GameObject.FindWithTag("Player").transform;


    }

    // Se ejecuta cada frame, pero después de haber procesado todo. Es más exacto 
    void Update()
    {
        float distancia;
        distancia = Vector3.Distance(perseguido.transform.position, transform.position);
        if (distancia <= distanciaSeguir)
        {
            //Voltear
            perseguidor.rotation = Quaternion.Slerp(perseguidor.rotation, Quaternion.LookRotation(perseguido.position - perseguidor.position), velocidadRotacion * Time.deltaTime);
            //Caminar
            perseguidor.position += perseguidor.forward * velocidad * Time.deltaTime;



        }
    }
}