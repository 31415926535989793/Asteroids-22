using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script para la creacion de la nave.
public class NaveManager : MonoBehaviour
{
    //Declaracion de variables
    public GameObject nave;
    public bool vivo = false;
    public float time = -60;
    public float aparece = 1000;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        //La nave aparece a partir de los 1000pts, en caso que que no exista ya una nave y cada 60s una vez se la mata.
        float tiempo = Time.time;
        tiempo = tiempo - time;
        if (GameManager.instance.points >= aparece && vivo == false && tiempo >= 60)
        {
            CreateNave();
        }
    }

    //Funciin para crear la nave.
    void CreateNave()
    {
        Vector3 position = new Vector3(-9, (Random.Range(-3, 3)), 0);
        Vector3 rotation = new Vector3(0, 0, 0);
        GameObject temp = Instantiate(nave, position, Quaternion.Euler(rotation));
        temp.GetComponent<NaveController>().manager = this;

    }


}
