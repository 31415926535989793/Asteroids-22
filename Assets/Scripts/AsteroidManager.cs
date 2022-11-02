using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script que controla la creacion de asteroides
public class AsteroidManager : MonoBehaviour
{
    //Declaracion de variables.
    public int asteroids_min = 2;
    public int asteroids_max = 5;
    public int asteroids;
    public GameObject asteroid;
    public float limitX = 10;
    public float limitY = 6;

    // Start is called before the first frame update
    void Start()
    {
        CreateAsteroids();
      
    }

    // Update is called once per frame
    void Update()
    {
        //Aumenta en 2 el min i max de asteroides que pueden spawnear en el siguiente nivel y los crea.
        if(asteroids <= 0 && GameManager.instance.points > 0)
        {
            asteroids_min += 2;
            asteroids_max += 2;
            CreateAsteroids();
        }
    }

    //Funcion para crear los asteroides y que parezcan en una posicion aleatoria en el mapa excepto en el medio(donde spawnea el personaje).
    void CreateAsteroids()
    {
        int asteroids = Random.Range(asteroids_min, asteroids_max);

        for (int i = 0; i < asteroids; i++)
        {
            Vector3 position = new Vector3(Random.Range(-limitX, limitX), Random.Range(-limitY, limitY));

            while (Vector3.Distance(position, new Vector3(0,0)) < 2)
            {
                position = new Vector3(Random.Range(-limitX, limitX), Random.Range(-limitY, limitY));
            }

            Vector3 rotation = new Vector3(0, 0, Random.Range(0f, 360f));
            GameObject temp = Instantiate(asteroid, position, Quaternion.Euler(rotation));
            temp.GetComponent<AsteroidControl>().manager = this;
        }
    }
}
