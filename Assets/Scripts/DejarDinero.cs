using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DejarDinero : MonoBehaviour {

    public static int varoSwat;
    public bool activateTrigger = false;
    public Text totalMoney;

    public Text dineroConseguido;

    // Use this for initialization
    void Start () {
        varoSwat = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Trigger();
        totalMoney.text = "$"+varoSwat.ToString();
        dineroConseguido.text = "Stolen money: " + varoSwat.ToString();
    }

    public void Trigger()
    {

        if (activateTrigger && Input.GetKeyDown(KeyCode.E))
        {
           
            varoSwat = varoSwat + TakeObject.varo;
            TakeObject.varo = 0;

        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
           

                activateTrigger = true;
        }

    }
}
