using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullSyringeScript : MonoBehaviour {

    private void Update()
    {
        if (gameObject.tag == "FullSyringe")
        {
            if (gameObject.transform.parent != null)
            {
                if (gameObject.transform.parent.gameObject.GetComponent<GetChildInSnap>() != null)
                {
                    if (gameObject.transform.parent.name == "SnapDropZone")
                    {
                        GameObject snapdrop = gameObject.transform.GetChild(0).gameObject;
                        GameObject syringe = snapdrop.transform.GetChild(1).gameObject;
                        syringe.GetComponent<SyringeScript>().StartCoroutine(syringe.GetComponent<SyringeScript>().insertLiquidMovement());
                        gameObject.tag = "UsedSyringe";
                    }
                }
                
            }
        }
    }
}
