using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VANASScript : MonoBehaviour {
    public List<GameObject> leftDrawers = new List<GameObject>();
    public List<GameObject> middleDrawers = new List<GameObject>();
    public List<GameObject> rightDrawers = new List<GameObject>();

    protected List<GameObject> allDrawers = new List<GameObject>();

    protected int Leftslot, middleSlot, rightSlot;
    private void Start()
    {
        for (int i = 0; i < leftDrawers.Count; i++)
        {
            allDrawers.Add(leftDrawers[i]);
        }

        for (int i = 0; i < middleDrawers.Count; i++)
        {
            allDrawers.Add(middleDrawers[i]);
        }

        for (int i = 0; i < rightDrawers.Count; i++)
        {
            allDrawers.Add(rightDrawers[i]);
        }


    }
    public void closeAllDrawersAcceptSelected(GameObject _selectedDrawer)
    {
        for (int i = 0; i < allDrawers.Count; i++)
        {
            if (allDrawers[i] != _selectedDrawer)
            {
                StartCoroutine(allDrawers[i].GetComponent<DrawerControllScript>().closeDrawer());
            }
        }
    }
    public void closeAllDrawersAcceptSelected()
    {
        for (int i = 0; i < allDrawers.Count; i++)
        {
                StartCoroutine(allDrawers[i].GetComponent<DrawerControllScript>().closeDrawer());
        }
    }
    public void chooseRandomDrawer()
    {
        closeAllDrawersAcceptSelected();
        lockCloset();
        middleSlot = Random.Range(0, middleDrawers.Count - 1);
        rightSlot = Random.Range(0, rightDrawers.Count - 1);

        GameObject middleDrawer, rightDrawer;

        middleDrawer = middleDrawers[middleSlot];
        rightDrawer = rightDrawers[rightSlot];

        middleDrawer.GetComponent<DrawerControllScript>().unlockDrawer();
        rightDrawer.GetComponent<DrawerControllScript>().unlockDrawer();
    }

    protected void lockCloset()
    {
        for (int i = 0; i < leftDrawers.Count; i++)
        {
            leftDrawers[i].GetComponent<DrawerControllScript>().lockDrawer();
        }
        for (int i = 0; i < middleDrawers.Count; i++)
        {
            middleDrawers[i].GetComponent<DrawerControllScript>().lockDrawer();
        }
        for (int i = 0; i < rightDrawers.Count; i++)
        {
            rightDrawers[i].GetComponent<DrawerControllScript>().lockDrawer();
        }
    }
}
