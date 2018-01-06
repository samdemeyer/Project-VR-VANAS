using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SyringeScript : MonoBehaviour {
    protected bool activeCavas = false;
    protected bool hasSnapped = false;
    protected bool isFilled = false;
    protected Text fillingProgressText;
    public int counter = 0;

    void Update () {
        
        if (gameObject.transform.parent != null && !hasSnapped)
        {
            if (gameObject.transform.parent.name == "SnapDropZone")
            {
                Debug.Log(findFillPoint().gameObject.transform.position.y);
                hasSnapped = true;
                
            }
        }
    }
    protected GameObject findFillPoint()
    {
        GameObject fillPoint = null;
        GameObject parent = gameObject.transform.parent.gameObject.transform.parent.gameObject;
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            if (parent.transform.GetChild(i).gameObject.name == "FillPoint")
            {
                fillPoint = parent.transform.GetChild(i).gameObject;
            }
        }
        return fillPoint;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject != null)
        {
            if (collision.transform.childCount >= 1)
            {
                if (collision.gameObject.transform.GetChild(0).tag == "InsertableMedTop" && hasSnapped)
                {
                    GameObject _toAdd = gameObject.transform.parent.gameObject.transform.parent.gameObject;
                    _toAdd.transform.localScale = new Vector3(2, 2, 2);
                    GameObject.Find("PlayerMemory").GetComponent<InventoryScript>().addItemToInventory(_toAdd);
                    StopAllCoroutines();
                }
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject != null)
        {
            if (collision.transform.childCount >= 1)
            {
                if (collision.gameObject.transform.GetChild(0).tag == "InsertableMedTop" && hasSnapped)
                {
                    if (hasSnapped && !isFilled)
                    {
                        GameObject parent = gameObject.transform.parent.gameObject.transform.parent.gameObject;
                        GameObject objectToPull = parent.transform.GetChild(3).gameObject;
                        StartCoroutine(pullLiquidMovement(objectToPull));
                        if (!activeCavas)
                        {
                            setCanvases();
                        }
                        
                        fillingProgressText = GameObject.Find("fillingProcess").GetComponent<Text>();
                        StartCoroutine(setFillingText(fillingProgressText));
                        
                    }
                }
            }
            
        }
    }

    public IEnumerator pullLiquidMovement(GameObject _objectToPull)
    {
        isFilled = true;
        float maxYPos = findFillPoint().transform.localPosition.y;
        GameObject syringeContent = _objectToPull.transform.GetChild(1).gameObject;

        Vector3 startPos = _objectToPull.transform.localPosition;
        Vector3 endPos = new Vector3(_objectToPull.transform.localPosition.x, maxYPos, _objectToPull.transform.localPosition.z);

        Vector3 startSize = syringeContent.transform.localScale;
        Vector3 endSize = new Vector3(startSize.x, 405, startSize.z);
        float timeSinceStarted = 0f;
        while (true)
        {
            timeSinceStarted += Time.deltaTime;
            _objectToPull.transform.localPosition = Vector3.Lerp(startPos, endPos, timeSinceStarted);
            syringeContent.transform.localScale = Vector3.Lerp(startSize, endSize, timeSinceStarted);
            // If the object has arrived, stop the coroutine
            if (_objectToPull.transform.localPosition == endPos)
            {
                
                yield break;
            }
            // Otherwise, continue next frame
            yield return null;
        }
    }
    public IEnumerator setFillingText(Text _fillingprogress)
    {       
        while (true)
        {
                counter += 50;
                Debug.Log(counter.ToString());
                _fillingprogress.text = counter.ToString();
                yield return new WaitForSeconds(1);
            
        }
    }

    protected void setCanvases()
    {
        GameObject canvases = GameObject.Find("Canvases");
        for (int i = 0; i < canvases.transform.childCount; i++)
        {
            canvases.transform.GetChild(i).gameObject.SetActive(false);
        }
        canvases.transform.GetChild(canvases.transform.childCount - 1).gameObject.SetActive(true);
    }
}
