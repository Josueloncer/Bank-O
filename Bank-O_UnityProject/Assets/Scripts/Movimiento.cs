using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {

    CharacterController charControl;
    public float velocidad;
    private bool left;
    private bool right;


    // Use this for initialization
    
 
    void Start()
    {
        left = true;
        right = false;
    }



    void Awake () {
        charControl = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

        MovePlayer();

    }

    void MovePlayer()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        float moveDirSide = /*transform.right */ horiz * velocidad * Time.deltaTime;
        float moveDirForward = /*transform.forward */ vert * velocidad * Time.deltaTime;

        //charControl.SimpleMove(moveDirSide);
        //charControl.SimpleMove(moveDirForward);
        transform.Translate(moveDirSide, 0, moveDirForward);




    }
}
