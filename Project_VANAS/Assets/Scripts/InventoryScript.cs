using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour {
    private List<GameObject> inventory = new List<GameObject>();
    public VRTK.VRTK_InteractGrab handHoldingItems;
    public GameObject[] itemPositions;
    public GameObject smallCube;
    protected bool inventoryFull = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.I))
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                Debug.Log(i+ "in inventory " +inventory[i]);
            }
        }
	}
    public void addItemToInventory(GameObject _gameobject)
    {
        if (_gameobject.tag == "MedObject")
        {
            if (itemPositions[8].transform.childCount == 0)
            {
                int i = 0;

                while (checkIfObjectHasChildren(itemPositions[i]) && i < 8)
                {

                    i++;
                }

                if (i < 9)
                {
                    //Debug.Log("create item at spot " + i);
                    GameObject smallItem = Instantiate(_gameobject);
                    inventory.Add(smallItem);
                    smallItem.transform.parent = itemPositions[i].transform;
                    smallItem.transform.position = new Vector3(itemPositions[i].transform.position.x, itemPositions[i].transform.position.y + 0.5f, itemPositions[i].transform.position.z);
                    smallItem.name = createNameForNewItem(_gameobject);
                    // smallItem.transform.localScale = smallItem.transform.localScale * 4;
                    
                    smallItem.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    smallItem.tag = "SmallItemToInstantiate";
                    smallItem.SetActive(true);
                }
            }
        }
        
        

    }
    protected bool checkIfObjectHasChildren(GameObject _inventoryIndex)
    {
        if (_inventoryIndex.transform.childCount == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
        
    }

    public void RemoveItemFromInventory(GameObject _gameobject)
    {
        inventory.Remove(_gameobject);
    }
    public List<GameObject> returnInventory()
    {
        return inventory;
    }
    protected void findGameObject(string _name)
    {
        GameObject activeObject = null;
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].name == _name)
            {
                activeObject = inventory[i];
                setObjectPosition(activeObject);
            }
        }
    }
    protected void setObjectPosition(GameObject _activeObject)
    {
        Debug.Log("Setobjectposition from btnclick " +_activeObject.name);
        _activeObject.SetActive(true);
        //_activeObject.transform.parent = handHoldingItems.transform;
        _activeObject.transform.position = handHoldingItems.transform.position;
        RemoveItemFromInventory(_activeObject);

    }
    public void emptyHand()
    {
        Debug.Log("buttonpressed");
        for (int i = 0; i < inventory.Count; i++)
        {
            inventory[i].SetActive(false);
        }
    }
    protected string createNameForNewItem(GameObject _objectToAdd)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].gameObject.name == _objectToAdd.name)
            {
                _objectToAdd.name = _objectToAdd.name + "I";
            }
        }
        return _objectToAdd.name;
    }
    public void freeGameObject(GameObject _grabbedObject)
    {
        _grabbedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        Debug.Log(_grabbedObject.name + "is being held");
        _grabbedObject.transform.localScale = _grabbedObject.transform.localScale*2;
        _grabbedObject.transform.parent = null;
        _grabbedObject.tag = "Untagged";

    }
}
