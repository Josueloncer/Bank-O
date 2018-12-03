using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta : MonoBehaviour {
    
    public bool T_ActivatedOpen = true;
    public bool T_ActivatedClose = false;
    public bool activateTrigger = false;
    Animator animator;
    bool doorOpen;

    void Start()
    { 

        T_ActivatedOpen = true;
        T_ActivatedClose = false;

        animator = GetComponent<Animator>();
        doorOpen = false;




    }

    void Update()
    { 

        if (T_ActivatedOpen == true)
            T_ActivatedClose = false;

        else if (T_ActivatedClose == true)
            T_ActivatedOpen = false;

        if (activateTrigger && Input.GetKeyDown(KeyCode.E)) 
        {

            T_ActivatedOpen = false;
            T_ActivatedClose = true;
            doorOpen = true;

            if (doorOpen)
            {
                doorOpen = true;
                doorController("Open");
            }

        }
        else if (activateTrigger && Input.GetKey(KeyCode.F))
        {
            T_ActivatedOpen = true;
            T_ActivatedClose = false;


            if (doorOpen)
            {
                doorOpen = false;
                doorController("Close");
            }

        }
    }



    void OnTriggerEnter(Collider col) 
    {
        if (col.gameObject.tag == "Player")
        {

            activateTrigger = true;
            Debug.Log("Entro");

        }

    }


    void OnTriggerExit(Collider col) 
    {
        if (col.gameObject.tag == "Player")
        {
            activateTrigger = false;

        }

    }

    void doorController(string direction) 
    {
        animator.SetTrigger(direction);
    }

}
