using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PjMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    EdgeCollider2D colider;
    SpriteRenderer sprite;
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
        
    }

    public void Dead()
    {
        GameObject temp = Instantiate(particulasMuerte, transform.position, transform.rotation);
        Destroy(temp, 1.5f);

        if (GameManager.instance.lives <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
        }
        else
        {
            StartCoroutine(respawn_coroutine());
        }

    }

    IEnumerator respawn_coroutine()
    {
        colider.enabled = false;
        sprite.enabled = false;
        yield return new WaitForSeconds(1);
        colider.enabled = true;
        sprite.enabled = true;

        GameManager.instance.lives -= 1;
        transform.position = new Vector3(0, 0, 0);
        rb.velocity = new Vector2(0, 0);

    }
}
