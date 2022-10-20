using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int lives;
    public int points;

    private void Awake()
    {
        instance = this; 
    }


}
