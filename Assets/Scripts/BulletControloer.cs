using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script para controlar la bala del personaje.
public class BulletControloer : MonoBehaviour
{
    //Declaracion de variables
    Rigidbody2D rb;
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Trigger para que las balas destruyan asteroides y la nave.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Asteroid")
        {
            collision.gameObject.GetComponent<AsteroidControl>().Dead();
            Destroy(gameObject);
        }
        if (collision.tag == "Nave")
        {
            collision.gameObject.GetComponent<NaveController>().Dead();
            Destroy(gameObject);
        }
    }
}
