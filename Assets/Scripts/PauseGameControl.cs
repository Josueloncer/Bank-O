using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameControl : MonoBehaviour {
    public GameObject menuPausa;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        menuPausa.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            ShowCursor();
            menuPausa.SetActive(!menuPausa.activeInHierarchy);
        }

        if(menuPausa.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
	}

    public void ShowCursor()
    {
        if(Cursor.visible)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }

    public void Continue()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        menuPausa.SetActive(false);
    }
}
