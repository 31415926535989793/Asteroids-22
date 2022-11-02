using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script para controlar los botones del menu de pausa
public class ButtonPauseControl : MonoBehaviour
{

    public int index;
    public bool cambio;
    public GameObject boton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pause();
        }
    }

    //Funcion para el boton de pausa
    public void pause()
    {
        boton.SetActive(true);
        Time.timeScale = 0;
    }

    //Funcion para el boton de continuar jugando.
    public void continua()
    {
        boton.SetActive(false);
        Time.timeScale = 1;
    }

    //Funcion para el boton de volver al menu de inicio.
    public void volver()
    {
        SceneManager.LoadScene("Inicio");
        Time.timeScale = 1;
    }
}
