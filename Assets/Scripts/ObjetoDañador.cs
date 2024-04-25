using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoDañador : MonoBehaviour
{
    
    private GameManager gameManager;

    void OnCollisionEnter(Collision other)
    {
        //En caso de colisionar con el player
        if (other.gameObject.tag == "Player")
        {
  
            other.gameObject.GetComponent<ControlVida>().RestarVida();
            
        }
    }  
 
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
