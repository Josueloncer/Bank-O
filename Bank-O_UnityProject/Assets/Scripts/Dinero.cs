using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dinero : MonoBehaviour
{

    public static int dineroo;
    public Text dinero;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        dinero.text = "Dinero" + dineroo;
    }
}
