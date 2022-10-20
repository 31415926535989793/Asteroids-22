using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float max_speed;
    public float min_speed;
    public AsteroidManager manager;

    // Start is called before the first frame update
    void Start()
    {
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

    public void Dead()
    {
        if(transform.localScale.x > 0.25f)
        {
            GameObject temp1 = Instantiate(manager.asteroid, transform.position, transform.rotation);
            temp1.GetComponent<AsteroidControl>().manager = manager;
            temp1.transform.localScale = transform.localScale * 0.5f;

            GameObject temp2 = Instantiate(manager.asteroid, transform.position, transform.rotation);
            temp2.GetComponent<AsteroidControl>().manager = manager;
            temp2.transform.localScale = transform.localScale * 0.5f;
        }
        GameManager.instance.points += 10;
        manager.asteroids -= 1;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pj")
        {
            collision.gameObject.GetComponent<PjMovement>().Dead();
        }
    }

}
