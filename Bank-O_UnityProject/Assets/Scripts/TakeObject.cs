using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeObject : MonoBehaviour {

    private bool InTrigger = false;
    string tagBilletes = "Billetes";
    string tagOro = "Oro";
    GameObject objectTrigger;
    public Text textoVaro;
    private int varo = 0;

	// Use this for initialization
	void Start () {
        textoVaro.text = "$" + varo.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if(InTrigger)
        {
            if(Input.GetMouseButtonDown(0))
            {
                CatchMoney();
            }
        }
    }

    public void CatchMoney()
    {
        if(objectTrigger.tag == tagBilletes)
        {
            Debug.Log("Agarraste billullo");
            varo += 1000;
            Destroy(objectTrigger.transform.parent.gameObject);
        }else if(objectTrigger.tag == tagOro)
        {
            Debug.Log("Agarraste oro");
            varo += 10000;
            Destroy(objectTrigger.transform.parent.gameObject);
        }
        UpdateMoney();
    }

    public void UpdateMoney()
    {
        textoVaro.text = "$" + varo.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        InTrigger = true;
        objectTrigger = other.gameObject;
    }

    private void OnTriggerStay(Collider other)
    {
        objectTrigger = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        InTrigger = false;
        objectTrigger = null;
    }
}
