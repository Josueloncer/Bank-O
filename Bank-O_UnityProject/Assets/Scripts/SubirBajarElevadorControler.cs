using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirBajarElevadorControler : MonoBehaviour {
    public ElevatorManager elevatorManager;
    public GameObject pisoDesaparecer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(elevatorManager.transform.position.y >= elevatorManager.ElevetorUpY)
        {
            pisoDesaparecer.GetComponent<BoxCollider>().enabled = true;
        }else if(elevatorManager.transform.position.y <= elevatorManager.ElevetorDownY)
        {
            pisoDesaparecer.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pisoDesaparecer.GetComponent<BoxCollider>().enabled = false;
                //elevatorManager.OpenElevator();
                elevatorManager.MoveElevator();
            }
        }
    }
}
