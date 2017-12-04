using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VANASScript : MonoBehaviour {
    public List<GameObject> leftDrawers = new List<GameObject>();
    public List<GameObject> middleDrawers = new List<GameObject>();
    public List<GameObject> rightDrawers = new List<GameObject>();

    protected int Leftslot, middleSlot, rightSlot;

    public void chooseRandomDrawer()
    {
        lockCloset();
        Leftslot = Random.Range(0, leftDrawers.Count - 1);
        middleSlot = Random.Range(0, middleDrawers.Count - 1);
        rightSlot = Random.Range(0, rightDrawers.Count - 1);

        GameObject leftDrawer, middleDrawer, rightDrawer;

        leftDrawer = leftDrawers[Leftslot];
        middleDrawer = middleDrawers[middleSlot];
        rightDrawer = rightDrawers[rightSlot];

        leftDrawer.GetComponent<DrawerControllScript>().unlockDrawer();
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
