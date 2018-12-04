using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour {

    public float mouseSensitivity;
    public Transform playerBody;

    float xAxisClamp = 0.0f;
    // Use this for initialization

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        RotateCamera();
	}

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotAmountX = mouseX * mouseSensitivity;
        float rotAmountY = mouseY * mouseSensitivity;

        Vector3 targetRotCam = transform.rotation.eulerAngles;
        Vector3 targetRotBody = playerBody.rotation.eulerAngles;

        targetRotCam.x -= rotAmountY;
        targetRotBody.y += rotAmountX;
        targetRotCam.z = 0;

        xAxisClamp -= rotAmountY;

        if(xAxisClamp >90)
        {
            xAxisClamp = 90;
            targetRotCam.x = 90;
        }

        else if(xAxisClamp < -90)
        {
            xAxisClamp = -90;
            targetRotCam.x = 270;
        }
        transform.rotation = Quaternion.Euler(targetRotCam);
        playerBody.rotation = Quaternion.Euler(targetRotBody);
    }
}
