using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Declaracion de variables.
    public static GameManager instance;
    public int lives;
    public int points;
    public int escudos = 3;

    private void Awake()
    {
        instance = this; 
    }


}
