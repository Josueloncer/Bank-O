using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoint : MonoBehaviour {
    //[HideInInspector]
    public bool isColliding;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Plane" && other.gameObject.tag != "Enemy")
        {
            isColliding = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isColliding = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "Plane" && other.gameObject.tag != "Enemy")
        {
            isColliding = true;
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag != "Plane")
    //    {
    //        isColliding = true;
    //        Debug.Log("colliding");
    //    }
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    isColliding = false;
    //}
}
