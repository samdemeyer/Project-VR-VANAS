using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour {
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.childCount >= 1) { 
            if (collision.gameObject.transform.GetChild(0).tag == "DissolvableMedTop")
            {
            Debug.Log("Change color");
            setColor(Color.red);
            }
        }
    }

    protected void setColor(Color _newcolor)
    {
        GameObject button = gameObject.transform.GetChild(0).gameObject;
        Renderer buttonColor = button.GetComponent<Renderer>();
        buttonColor.material.color = _newcolor;
    }
}
