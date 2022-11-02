using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script que controla al personaje(su movimiento, powerups, disparo, animaciones...)
public class PjMovement : MonoBehaviour
{
    //Declaración de todas las variables
    Rigidbody2D rb;
    Animator anim;
    EdgeCollider2D colider;
    SpriteRenderer sprite;
    Teleporter tele;
    public float speed = 10;
    public float rotationspeed = 10;
    public int dobleShoot = 100;
    public int hiper = 100;
    public int escudo = 100;
    public GameObject bala;
    public GameObject shield;
    public Transform firepoint;
    public Transform firepointR;
    public Transform firepointL;
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
        //Añadir una fuerza al personaje, se mueve con las teclas ("w") o ("up"). 
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

        //Añadir la rotacion de la nave, se mueve con las teclas ("a" y "d") o ("left" y "right").
        float horizontal = Input.GetAxis("Horizontal");
        transform.eulerAngles += new Vector3(0, 0, horizontal * rotationspeed * Time.deltaTime);

        //Diferentes estilos de disparo al apretar el boton "Jump" = space.
        if (Input.GetButtonDown("Jump"))
        {        
            //Doble disparo(En el momento que aparece la nave(1000pts) el jugador pasa a tener un disparo con dos balas)
            if (GameManager.instance.points >= dobleShoot)
            {
                GameObject tempR = Instantiate(bala, firepointR.position, transform.rotation);
                GameObject tempL = Instantiate(bala, firepointL.position, transform.rotation);
                Destroy(tempR, 1f);
                Destroy(tempL, 1f);
            }
            //Disparo normal en el que sale una bala cada vez que apretamos space.
            else
            {
                GameObject temp = Instantiate(bala, firepoint.position, transform.rotation);
                Destroy(temp, 1f);
            }
        }

        //Hiperespacio(Teleport a una posicion aleatoria en la pantalla; Hiper = "n"), aparece como PowerUp
        //a partir de los 500 pts.
        if (Input.GetButtonDown("Hiper"))
        {
            if(GameManager.instance.points >= hiper)
            {
                Vector3 position = new Vector3(Random.Range(-tele.limitX, tele.limitX), Random.Range(-tele.limitY, tele.limitY));
                transform.position = position;
            }
        }

        //Escudo(Una vez se alcalzan un determinado numero de pts puedes activar un escudo con la tecla "Escudo" = n;
        //Este escudo durará un total de 10 segundos en los que nada puede destruire y el escudo lo destruye todo,
        //Solo se puede usar una vez en toda la partida.
        if (Input.GetButtonDown("Escudo"))
        {
            if (GameManager.instance.points >= escudo)
            {
                if(GameManager.instance.escudos >= 1)
                {
                    shield.SetActive(true);
                    GameManager.instance.escudos --;
                }
            }
        }
    }

    //Funcion de muerte del personaje.
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

    //Coroutine para el respawn en el centro con 1s de delay y quieto.
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
