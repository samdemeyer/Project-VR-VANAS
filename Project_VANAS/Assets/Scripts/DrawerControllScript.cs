using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerControllScript : MonoBehaviour {
    public bool isLocked = true;
    protected Vector3 startPosition;
    protected bool onPosition = true;
    protected bool wasOpened = false;

    protected void setColor(Color _newcolor)
    {
        GameObject button = gameObject.transform.GetChild(0).gameObject;
        Renderer buttonColor = button.GetComponent<Renderer>();
        buttonColor.material.color = _newcolor;
    }
    public void unlockDrawer()
    {
        gameObject.GetComponent<VRTK.VRTK_InteractableObject>().enabled = true;
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
    private void Start()
    {
        startPosition = gameObject.transform.position;
        gameObject.GetComponent<VRTK.VRTK_InteractableObject>().enabled = false;
        //Debug.Log(gameObject.transform.GetChild(0).gameObject.name);
    }
    public IEnumerator closeDrawer()
    {
        float timeSinceStarted = 0f;
        while (true)
        {
            timeSinceStarted += Time.deltaTime;
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, startPosition, timeSinceStarted);

            // If the object has arrived, stop the coroutine
            if (gameObject.transform.position == startPosition)
            {
                if (wasOpened)
                {
                    lockDrawer();
                }
                yield break;
            }
            else
            {
                wasOpened = true;
            }

            // Otherwise, continue next frame
            yield return null;
        }
    }


}
