using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour {
    private List<GameObject> inventory = new List<GameObject>();
    public VRTK.VRTK_InteractGrab handHoldingItems;
    public Image[] inventoryIMGS;
    public Sprite[] medicineSprites;
    protected bool inventoryFull = false;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < inventoryIMGS.Length; i++)
        {
            inventoryIMGS[i].gameObject.SetActive(false);
        }
	}
    public void addItemToInventory(GameObject _gameobject)
    {
        if (_gameobject.tag == "MedObject")
        {
            if (!inventoryIMGS[8].gameObject.activeSelf)
            {
                int i = 0;

                while (inventoryIMGS[i].gameObject.activeSelf && i < 8)
                {

                    i++;
                }
                Debug.Log("propt of img " + i.ToString());
                if (i < 9)
                {
                    //parent is PlayerMemory
                    GameObject itemInInventory = Instantiate(_gameobject);
                    inventory.Add(itemInInventory);
                    itemInInventory.transform.parent = handHoldingItems.transform;
                    itemInInventory.name = createNameForNewItem(_gameobject);
                    itemInInventory.tag = "SmallItemToInstantiate";
                    itemInInventory.SetActive(false);

                    inventoryIMGS[i].sprite = returnSprite(_gameobject.name);
                    inventoryIMGS[i].gameObject.GetComponent<Button>().onClick.AddListener(() => setObjectPosition(itemInInventory, inventoryIMGS[i].gameObject));
                    if (inventoryIMGS[i].sprite != null)
                    {
                        inventoryIMGS[i].gameObject.SetActive(true);
                    }
                    
                }
            }
        }
        
        

    }
    protected void test()
    {
        Debug.Log("You clicked on the img");
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
    /*protected void findGameObject(string _name)
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
    }*/
    protected void setObjectPosition(GameObject _activeObject, GameObject _position)
    {
        Debug.Log("Setobjectposition from btnclick " +_activeObject.name);
        _activeObject.SetActive(true);
        _activeObject.transform.parent = handHoldingItems.gameObject.transform;
        _activeObject.transform.localPosition = Vector3.zero;
        // _activeObject.transform.localRotation = _position.gameObject.transform.localRotation;
        //_activeObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        _activeObject.GetComponent<Rigidbody>().useGravity = false;
        RemoveItemFromInventory(_activeObject);
        _position.gameObject.SetActive(false);
        removeOnClicks(_position);
    }
    protected void removeOnClicks(GameObject _button)
    {
        _button.GetComponent<Button>().onClick.RemoveAllListeners();
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
        _grabbedObject.GetComponent<Rigidbody>().useGravity = true;
        Debug.Log(_grabbedObject.name + "is being held");
        //_grabbedObject.transform.localScale = _grabbedObject.transform.localScale*2;
        _grabbedObject.transform.parent = null;
        _grabbedObject.tag = "Untagged";

    }
    protected Sprite returnSprite(string _name)
    {
        Sprite spriteToReturn = null;
        for (int i = 0; i < medicineSprites.Length; i++)
        {
            if (medicineSprites[i].name == _name)
            {
                spriteToReturn = medicineSprites[i];
            }
        }
        return spriteToReturn;
    }
}
