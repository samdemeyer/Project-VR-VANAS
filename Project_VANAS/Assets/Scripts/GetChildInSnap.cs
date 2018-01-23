using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetChildInSnap : MonoBehaviour {
    public bool isSnapped;
    public void setSnappedFalse()
    {
        isSnapped = false;
        Debug.Log("is NOT snapped");
    }
    public void setSnappedTrue()
    {
        isSnapped = true;
        Debug.Log("is snapped");
    }
    public bool returnState()
    {
        return isSnapped;
    }
}
