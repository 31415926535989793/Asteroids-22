using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script para controlar la bala de la nave.
public class BulletNaveController : MonoBehaviour
{
    //Declaracion de variables
    Rigidbody2D rb;
    public float speed;

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

    public void Dead()
    {
        Destroy(gameObject);
    }

    //Trigger para matar al personaje cuando le da la bala.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pj")
        {
            collision.gameObject.GetComponent<PjMovement>().Dead();
            Destroy(gameObject);
        }
    }
}