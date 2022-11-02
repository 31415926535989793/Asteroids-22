using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script que controla el objeto nave.
public class NaveController : MonoBehaviour
{
    //Declaracion de variables.
    Rigidbody2D rb;
    public NaveManager manager;
    public GameObject bala;
    public float max_speed;
    public float min_speed;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        //Añade una fuerza a la nave para que se mueva de forma horizontal y recoge el tiempo en el que aparece.
        rb = GetComponent<Rigidbody2D>();
        Vector2 direccion = new Vector2(Random.Range(-1f, 1f), 0);
        direccion = direccion * Random.Range(min_speed, max_speed);
        rb.AddForce(direccion);
        manager.vivo = true;
        time = Time.time;   
    }

    // Update is called once per frame
    void Update()
    {
        //Disparo de la nave, cada 0.5s dispara una bala en una direccion aleatoria. 
        float tiempo = Time.time - time;
        if (tiempo >= 0.5f)
        {
            Vector3 rotation = new Vector3(0, 0, Random.Range(0f, 360f));
            GameObject temp = Instantiate(bala, transform.position, Quaternion.Euler(rotation));
            Destroy(temp, 1f);
            time = Time.time;
        }
       
    }

    //Funcion de muerte de la nave y recoge el tiempo en el que muere.
    public void Dead()
    {
        GameManager.instance.points += 200;
        manager.vivo = false;
        Destroy(gameObject);
        manager.time = Time.time;
    }

    //Trigger para que al chocar con el personaje, este muera.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pj")
        {
            collision.gameObject.GetComponent<PjMovement>().Dead();
        }
    }
}
