using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour {
    //Escala -- para abrir las puertas
    //0.13405
    [SerializeField]
    private GameObject puertaIzq;
    [SerializeField]
    private GameObject puertaDer;

    private float scaleSpeed = 0.5f;
    private float goingUpSpeed = 0.5f;

    private float doorsClosedScale = 1f;
    private float doorsOpenScale = 0.13405f;
    private float ElevetorDownY = 0f;
    private float ElevetorUpY = 1.668f;

    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E))
        {
            OpenElevator();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveElevator();
        }
    }

    public void OpenElevator()
    {
        if(puertaIzq.transform.localScale.z > doorsOpenScale || puertaDer.transform.localScale.z > doorsOpenScale)
        {
            StopAllCoroutines();
            StartCoroutine("OpenDoors");
        }
        else if(puertaIzq.transform.localScale.z < doorsClosedScale || puertaDer.transform.localScale.z < doorsClosedScale)
        {
            StopAllCoroutines();
            StartCoroutine("CloseDoors");
        }
        
    }

    public void MoveElevator()
    {
        if (transform.position.y < ElevetorUpY)
        {
            StopAllCoroutines();
            StartCoroutine("GoingUp");
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine("GoingDown");
        }
    }

    IEnumerator GoingUp()
    {
        while (transform.position.y < ElevetorUpY)
        {
            transform.Translate(0, goingUpSpeed * Time.deltaTime, 0);

            yield return null;
        }
    }

    IEnumerator GoingDown()
    {
        while (transform.position.y > ElevetorDownY)
        {
            transform.Translate(0, -goingUpSpeed * Time.deltaTime, 0);

            yield return null;
        }
    }

    IEnumerator OpenDoors()
    {
        Debug.Log("Si lo ta haciendo");
        while (puertaIzq.gameObject.transform.localScale.z > doorsOpenScale || puertaDer.gameObject.transform.localScale.z > doorsOpenScale)
        {
            Debug.Log("Si lo ta haciendo");
            var auxScale1 = puertaIzq.gameObject.transform.localScale;
            auxScale1.z -= (scaleSpeed * Time.deltaTime);

            puertaIzq.gameObject.transform.localScale = auxScale1;

            var auxScale2 = puertaDer.gameObject.transform.localScale;
            auxScale2.z -= (scaleSpeed * Time.deltaTime);

            puertaDer.gameObject.transform.localScale = auxScale2;

            yield return null;
        }
    }

    IEnumerator CloseDoors()
    {
        while (puertaIzq.gameObject.transform.localScale.z < doorsClosedScale || puertaDer.gameObject.transform.localScale.z < doorsClosedScale)
        {
            var auxScale1 = puertaIzq.gameObject.transform.localScale;
            auxScale1.z += (scaleSpeed * Time.deltaTime);

            puertaIzq.gameObject.transform.localScale = auxScale1;

            var auxScale2 = puertaDer.gameObject.transform.localScale;
            auxScale2.z += (scaleSpeed * Time.deltaTime);

            puertaDer.gameObject.transform.localScale = auxScale2;

            yield return null;
        }
    }
}
