﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipboardScript : MonoBehaviour {
	// Use this for initialization
    public void setClipboardState()
    {
        if (gameObject.activeSelf == true)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
<<<<<<< HEAD
            gameObject.GetComponent<InventoryScript>().activateAllButtons();
=======
            //GameObject.Find("PlayerMemory").GetComponent<InventoryScript>().activateAllButtons();
>>>>>>> MichaelBranch
        }
    }
}
