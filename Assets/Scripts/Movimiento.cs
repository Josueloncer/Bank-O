using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
    public float velocidad;
    private bool left;
    private bool right;
    float moveDirSide = 0;
    float moveDirForward = 0;



    // Use this for initialization


    void Start()
    {
        left = true;
        right = false;
    }

	// Update is called once per frame
	void Update () {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        if(Input.GetKey(KeyCode.LeftShift))
        {
            moveDirSide = horiz * (velocidad * 1.8f) * Time.deltaTime;
            moveDirForward = vert * (velocidad * 1.8f) * Time.deltaTime;
        }
        else
        {
            moveDirSide = horiz * velocidad * Time.deltaTime;
            moveDirForward = vert * velocidad * Time.deltaTime;
        }

        transform.Translate(moveDirSide, 0, moveDirForward);
    }
}
