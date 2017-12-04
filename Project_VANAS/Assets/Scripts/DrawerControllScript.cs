using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerControllScript : MonoBehaviour {
    public bool isLocked = true;
    protected void setColor(Color _newcolor)
    {
        GameObject button = gameObject.transform.GetChild(0).gameObject;
        Renderer buttonColor = GetComponent<Renderer>();
        buttonColor.material.color = _newcolor;
    }
    public void unlockDrawer()
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        setColor(Color.green);
        isLocked = false;
    }
    public void lockDrawer()
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        setColor(Color.red);
        isLocked = true;
    }
    private void Update()
    {
        if (isLocked)
        {
            lockDrawer();
        }
        else
        {
            unlockDrawer();
        }
    }

}
