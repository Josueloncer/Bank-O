using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeableObject : MonoBehaviour {

    private bool InTrigger = false;
    string tagBilletes = "Billetes";
    string tagOro = "Oro";
    string tagObjectTrigger = "";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(InTrigger)
        {
            if(Input.GetMouseButton(0))
            {
                CatchMoney();
            }
        }
    }

    public void CatchMoney()
    {
        if(tagObjectTrigger == tagBilletes)
        {
            Debug.Log("Agarraste billullo");
        }else if(tagObjectTrigger == tagOro)
        {
            Debug.Log("Agarraste oro");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        InTrigger = true;
        tagObjectTrigger = other.gameObject.tag;
    }

    private void OnTriggerExit(Collider other)
    {
        InTrigger = false;
        tagObjectTrigger = "";
    }
}
