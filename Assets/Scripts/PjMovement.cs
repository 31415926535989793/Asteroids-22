using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PjMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    EdgeCollider2D colider;
    SpriteRenderer sprite;
    Teleporter tele;
    public float speed = 10;
    public float rotationspeed = 10;
    public GameObject bala;
    public Transform firepoint;
    public GameObject particulasMuerte;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        colider = GetComponent<EdgeCollider2D>();    
        sprite = GetComponent<SpriteRenderer>();
        tele = GetComponent<Teleporter>();  
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        if(vertical > 0)
        {
            rb.AddForce(transform.up * vertical * speed * Time.deltaTime);
            anim.SetBool("Impulsing", true);
        }
        else
        {
            anim.SetBool("Impulsing", false);
        }

        float horizontal = Input.GetAxis("Horizontal");
        transform.eulerAngles += new Vector3(0, 0, horizontal * rotationspeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            GameObject temp = Instantiate(bala, firepoint.position, transform.rotation);
            Destroy(temp, 1f);
        }

        //Hiperespacio(Teleport a una posicion aleatoria en la pantalla; Hiper = "c")
        if (Input.GetButtonDown("Hiper"))
        {
            Vector3 position = new Vector3(Random.Range(-tele.limitX, tele.limitX), Random.Range(-tele.limitY, tele.limitY));
            transform.position = position;  

        }

    }

    public void Dead()
    {
        GameObject temp = Instantiate(particulasMuerte, transform.position, transform.rotation);
        Destroy(temp, 1.5f);

        StartCoroutine(respawn_coroutine());
        if (GameManager.instance.lives < 1)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }

    IEnumerator respawn_coroutine()
    {
        GameManager.instance.lives -= 1;

        colider.enabled = false;
        sprite.enabled = false;
        yield return new WaitForSeconds(1);
        colider.enabled = true;
        sprite.enabled = true;

        transform.position = new Vector3(0, 0, 0);
        rb.velocity = new Vector2(0, 0);

    }
}
