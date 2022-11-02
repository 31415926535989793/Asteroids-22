using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script para controlar el escudo
public class EscudoController : MonoBehaviour
{
    //Declaracion de variables.
    public GameObject escudo;
    public float time;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Una vez pasados 10 segundos el escudo desaparece.
        float tiempo = Time.time;
        tiempo = tiempo - time;
        if (tiempo >= 10)
        {
            escudo.SetActive(false);
        }
    }

    //Recoge el tiempo en el que se activa el escudo.
    void OnEnable()
    {
        time = Time.time;
    }

    //Triggers para que el escudo destruya cualquier tipo de objeto menos la bala del jugador.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Asteroid")
        {
            collision.gameObject.GetComponent<AsteroidControl>().DeadEscudo();
        }
        if(collision.tag == "Nave")
        {
            collision.gameObject.GetComponent<NaveController>().Dead();
        }
        if (collision.tag == "BalaNave")
        {
            collision.gameObject.GetComponent<BulletNaveController>().Dead();
        }
    }
}
