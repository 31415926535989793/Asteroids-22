using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script para hacer el mapa infinito.
public class Teleporter : MonoBehaviour
{
    //Declaracion de variables
    public float limitX = 13;
    public float limitY = 7.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Para hacer el mapa infinito(que los objetos salgan por un lado y entren por la contraria).
        if(transform.position.y > limitY)
        {
            transform.position = new Vector3(transform.position.x, -limitY);
        }
        if (transform.position.y < -limitY)
        {
            transform.position = new Vector3(transform.position.x, limitY);
        }
        if (transform.position.x > limitX)
        {
            transform.position = new Vector3(-limitX, transform.position.y);
        }
        if (transform.position.x < -limitX)
        {
            transform.position = new Vector3(limitX, transform.position.y);
        }
  

    }
}
