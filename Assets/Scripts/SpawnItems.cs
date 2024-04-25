using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{

    //Lista de pistas a spawnear
    public GameObject[] listaItems;
    //Pista a spawnear
    private int itemIndex;
    GameObject item;
    
    //private int contador=0;
    //metodo para spawnear pistas
    void lanzaItem()
    {
        // List<int> numeros = new List<int>();
        // itemIndex = Random.Range(0, listaItems.Length);
         
         //verificamos números repetidos
         //if (!numeros.Any(x => x == itemIndex))
        // {
           //  numeros.Add(itemIndex);
        // } 
        //item = GameObject.FindGameObjectWithTag("Pista");
        //if (!item)
       // {
            Destroy(item);
            item = Instantiate(listaItems[0], transform.position, Quaternion.identity);
           // contador = contador + 1;
           //if (contador == 3)
           // {
               // contador = 0;
           // }

        }
       
        
        
           
       
    


  



    // Start is called before the first frame update
    void Start()
    {
       item= Instantiate(listaItems[0], transform.position, Quaternion.identity);
        InvokeRepeating("lanzaItem", 40, 40);
 }
    // Update is called once per frame
    void Update()
    {
        
    }

}
