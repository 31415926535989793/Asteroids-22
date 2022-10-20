using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
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
        if(asteroids <= 0)
        {
            asteroids_min += 2;
            asteroids_max += 2;
            CreateAsteroids();
        }
    }

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
