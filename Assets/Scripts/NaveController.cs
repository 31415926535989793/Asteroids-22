using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveController : MonoBehaviour
{
    Rigidbody2D rb;
    public NaveManager manager;
    public float max_speed;
    public float min_speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direccion = new Vector2(Random.Range(-1f, 1f), 0);
        direccion = direccion * Random.Range(min_speed, max_speed);
        rb.AddForce(direccion);
        manager.vivo = true;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Dead()
    {
        GameManager.instance.points += 200;
        manager.vivo = false;
        Destroy(gameObject);
        manager.time = Time.time;
    }
}
