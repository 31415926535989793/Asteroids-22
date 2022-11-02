using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script para controlar diferentes botones del menu de incicio y la escena de los controles.
public class ButtonControl : MonoBehaviour
{
    public int index;
    public bool cambio;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (cambio)
        {
            cambiarescena(index);
        }
    }
    
    //Funcion para cambiar de escena desed un boton.
    public void cambiarescena(int index)
    {
        SceneManager.LoadScene(index);
    }

}
