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
    public static int varo;
    public AudioSource sonido;

    public GameObject textFullMoney;
    private bool Dinerolleno;

	// Use this for initialization
	void Start () {
        varo = 0;
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
        MaxMoney();
        textoVaro.text = "$" + varo.ToString();
    }

    public void CatchMoney()
    {
        if(Dinerolleno == true)
            if(objectTrigger.tag == tagBilletes)
            {

                Debug.Log("Agarraste billullo");
                sonido.Play();
                varo += 100;

                Destroy(objectTrigger.transform.parent.gameObject);
            }else if(objectTrigger.tag == tagOro)
            {
                Debug.Log("Agarraste oro");
                varo += 10000;
                sonido.Play();
                Destroy(objectTrigger.transform.parent.gameObject);
            }
        UpdateMoney();
    }


    public void MaxMoney()
    {
        if(varo >= 20000)
        {
            Dinerolleno = false;
            textFullMoney.SetActive(true);
        }

        if(varo < 20000)
        {
            Dinerolleno = true;
            textFullMoney.SetActive(false);
        }
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
