using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

//Script para los textos en pantalla y las imagenes de las vidas.
public class UIManager : MonoBehaviour
{
    //DEclaracion de variables
    public TextMeshProUGUI time;
    public TextMeshProUGUI points;
    public TextMeshProUGUI lives;
    public GameObject pause;
    public GameObject gameover;
    public Image Vida1;
    public Image Vida2;
    public Image Vida3;
    public Image Escudo1;
    public Image Escudo2;
    public Image Escudo3;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Vida1);
        Instantiate(Vida2);
        Instantiate(Vida3);
        Instantiate(Escudo1);
        Instantiate(Escudo2);
        Instantiate(Escudo3);
        Escudo1.enabled = false;
        Escudo2.enabled = false;
        Escudo3.enabled = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Instanciar los diferentes textos e imagenes.
        time.text = Time.time.ToString("00.00");
        points.text = GameManager.instance.points.ToString();
        lives.text = GameManager.instance.lives.ToString();

        //Aparece el texto "Game Over" cuando las vidas llegan a 0 y por cada vida perdida se destruye una imagen que
        //representan las vidas.
        if (GameManager.instance.lives < 1)
        {
            gameover.SetActive(true);
            Vida3.enabled = false;
        }

        if (GameManager.instance.lives == 2)
        {
            Vida1.enabled = false;
        }

        if (GameManager.instance.lives == 1)
        {
            Vida2.enabled = false;
        }

        //Aparecen tres simbolos del escudo debajo de las vidas para indicar cuantos usos te quedan disponibles.
        if (GameManager.instance.points >= 500 && GameManager.instance.escudos == 3)
        {
            Escudo1.enabled = true;
            Escudo2.enabled = true;
            Escudo3.enabled = true;
        }

        if (GameManager.instance.escudos == 2)
        {
            Escudo1.enabled = false;
        }

        if (GameManager.instance.escudos == 1)
        {
            Escudo2.enabled = false;
        }

        if (GameManager.instance.escudos == 0)
        {
            Escudo3.enabled = false;
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        }
    }
      
}

