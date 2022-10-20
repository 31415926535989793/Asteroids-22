using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI time;
    public TextMeshProUGUI points;
    public TextMeshProUGUI lives;
    public GameObject gameover;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time.text = Time.time.ToString("00.00");
        points.text= GameManager.instance.points.ToString();
        lives.text= GameManager.instance.lives.ToString();

        if(GameManager.instance.lives <= 0)
        {
            gameover.SetActive(true);
        }
    }
}
