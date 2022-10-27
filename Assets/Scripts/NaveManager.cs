using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveManager : MonoBehaviour
{
    public GameObject nave;
    public bool vivo = false;
    public float time = -60;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        float tiempo = Time.time;
        tiempo = tiempo - time;
        if (GameManager.instance.points >= 1000 && vivo == false && tiempo >= 60)
        {
            CreateNave();
        }
    }


    void CreateNave()
    {
        Vector3 position = new Vector3(-9, 3, 0);
        Vector3 rotation = new Vector3(0, 0, 0);
        GameObject temp = Instantiate(nave, position, Quaternion.Euler(rotation));
        temp.GetComponent<NaveController>().manager = this;

    }


}
