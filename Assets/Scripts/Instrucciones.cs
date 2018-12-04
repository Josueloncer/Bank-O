using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrucciones : MonoBehaviour {

    public GameObject instrucciones;
    // Use this for initialization
    void Start () {
        instrucciones.SetActive(true);
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKey(KeyCode.Return))
        {
           instrucciones.SetActive(false);
        }
	}
}
