using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirBajarElevadorControler : MonoBehaviour {
    public ElevatorManager elevatorManager;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetMouseButtonDown(0))
            {
                elevatorManager.OpenElevator();
                elevatorManager.MoveElevator();
            }
        }
    }
}
