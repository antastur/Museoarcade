using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarPista : MonoBehaviour
{

    GameObject pista;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Destroy(gameObject, .5f);
        }

    }

    




}
