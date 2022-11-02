using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script que maneja un objeto asteroide.
public class AsteroidControl : MonoBehaviour
{
    //Declaracion de variables.
    Rigidbody2D rb;
    public float max_speed;
    public float min_speed;
    public AsteroidManager manager;

    // Start is called before the first frame update
    void Start()
    {
        //Añadir una fuerza hacia una direccion aleatoria al asteroide y mantener la cuenta de asteroides.
        rb = GetComponent<Rigidbody2D>();
        Vector2 direccion = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direccion = direccion * Random.Range(min_speed, max_speed);
        rb.AddForce(direccion);
        manager.asteroids += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Funcion de muerte del asteroide, las dos primeras veces que se destruye se divide en dos más pequeños.
    public void Dead()
    {
        if(transform.localScale.x > 0.4f)
        {
            GameObject temp1 = Instantiate(manager.asteroid, transform.position, transform.rotation);
            temp1.GetComponent<AsteroidControl>().manager = manager;
            temp1.transform.localScale = transform.localScale * 0.5f;

            GameObject temp2 = Instantiate(manager.asteroid, transform.position, transform.rotation);
            temp2.GetComponent<AsteroidControl>().manager = manager;
            temp2.transform.localScale = transform.localScale * 0.5f;
        }
        GameManager.instance.points += 50;
        manager.asteroids -= 1;
        Destroy(gameObject);
    }

    //Funcion de muerte cuando impacta contra el escudo, ya que el escudo destruye todos los objetos de golpe.
    public void DeadEscudo()
    {
        GameManager.instance.points += 50;
        manager.asteroids -= 1;
        Destroy(gameObject);
    }

    //Trigger para la destruccion del personaje una vez se choca con el.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pj")
        {
            collision.gameObject.GetComponent<PjMovement>().Dead();
        }
    }

}
