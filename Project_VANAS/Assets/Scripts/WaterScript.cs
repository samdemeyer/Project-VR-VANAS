using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour {
    private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.tag == "DissolvableMedTop")
            {
                Debug.Log("Change color");
                setColor(Color.red);
                gameObject.tag = "SolvedMedicine";
            }
    }

    protected void setColor(Color _newcolor)
    {
        GameObject button = gameObject.transform.GetChild(0).gameObject;
        Renderer buttonColor = button.GetComponent<Renderer>();
        buttonColor.material.color = _newcolor;
    }
}
