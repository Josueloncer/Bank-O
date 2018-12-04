using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour {

    public Text Tempo;
    public static float Tiempo = 120.0f;
    public GameObject perdiste;

    private void Start()
    {
        Tiempo = 120;
    }

    void Update()
    {
            Tiempo -= Time.deltaTime;
        // Primero se comprueba que sea falso el tener que aumentar.


            if (Tiempo <= 0.0f)  // Comprueba si es menor o igual a cero.
            {
            perdiste.SetActive(true);    
            }


        Tempo.text = "Time:" + " " + Tiempo.ToString("f0");
        
    }
}
