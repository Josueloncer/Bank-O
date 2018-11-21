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

    // Use this for initialization
    void Start () {
        OpenElevator();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenElevator()
    {
        StartCoroutine("OpenDoors");
    }

    IEnumerator OpenDoors()
    {
        Debug.Log("Si lo ta haciendo");
        while (puertaIzq.gameObject.transform.localScale.z > 0.13405 || puertaDer.gameObject.transform.localScale.z > 0.13405)
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
}
