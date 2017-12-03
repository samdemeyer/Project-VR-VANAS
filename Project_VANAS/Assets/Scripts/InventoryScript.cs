using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
=======
using UnityEngine.SceneManagement;
>>>>>>> MichaelBranch
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour {
    private List<GameObject> inventory = new List<GameObject>();
    public VRTK.VRTK_InteractGrab handHoldingItems;
<<<<<<< HEAD
    public Image buttonContainer;
    public Button buttonPrefab;
	// Use this for initialization
	void Start () {
=======
    public GameObject[] itemPositions;
    public GameObject smallCube;
    protected bool inventoryFull = false;
    // Use this for initialization
    void Start () {
>>>>>>> MichaelBranch
		
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
<<<<<<< HEAD
        if (Input.GetKey(KeyCode.B))
        {
            Button button = Instantiate(buttonPrefab, buttonContainer.transform);
            button.name = "TestButton";
            //button.onClick.AddListener(() => { findGameObject(_gameobject.name); });
            //button.onClick.AddListener(() => { setButtonStates(button); });
            button.transform.GetChild(0).GetComponent<Text>().text = "Test B1";
        }
	}
    public void addItemToInventory(GameObject _gameobject)
    {
        _gameobject.transform.parent = gameObject.transform;
        inventory.Add(_gameobject);

        Button button = Instantiate(buttonPrefab, buttonContainer.transform);
        button.name = _gameobject.name;
        button.onClick.AddListener(() => { findGameObject(_gameobject.name); });
        button.onClick.AddListener(() => { setButtonStates(button); });
        button.transform.GetChild(0).GetComponent<Text>().text = _gameobject.name;
        activateAllButtons();
    }
    /*public void RemoveItemFromInventory(GameObject _gameobject)
    {
        //inventory.Remove(_gameobject);
        Destroy(_gameobject);
    }*/
=======
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
                    GameObject smallItem = Instantiate(_gameobject, itemPositions[i].transform);
                    inventory.Add(smallItem);
                    smallItem.transform.position = new Vector3(itemPositions[i].transform.position.x, itemPositions[i].transform.position.y + 0.1f, itemPositions[i].transform.position.z);
                    smallItem.name = createNameForNewItem(_gameobject);
                    smallItem.transform.localScale = smallItem.transform.localScale * 4;
                    smallItem.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
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
>>>>>>> MichaelBranch
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
<<<<<<< HEAD
        
=======
        RemoveItemFromInventory(_activeObject);
>>>>>>> MichaelBranch

    }
    public void emptyHand()
    {
<<<<<<< HEAD
=======
        Debug.Log("buttonpressed");
>>>>>>> MichaelBranch
        for (int i = 0; i < inventory.Count; i++)
        {
            inventory[i].SetActive(false);
        }
    }
<<<<<<< HEAD
    public void setButtonStates(Button _clickedButton)
    {
        for (int i = 0; i < buttonContainer.transform.childCount; i++)
        {
            
            if (buttonContainer.transform.GetChild(i).gameObject == _clickedButton.gameObject)
            {
                Debug.Log("set button states, button: " + buttonContainer.transform.GetChild(i).gameObject.name + "setactive");
                buttonContainer.transform.GetChild(i).GetComponent<Button>().interactable = false ;
                
            }
            else
            {
                buttonContainer.transform.GetChild(i).GetComponent<Button>().interactable = true;
            }
        }
    }
    public void activateAllButtons()
    {
        for (int i = 0; i < buttonContainer.transform.childCount; i++)
        {
            buttonContainer.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }
=======
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
        _grabbedObject.transform.localScale = _grabbedObject.transform.localScale*10;
        _grabbedObject.transform.parent = null;
        _grabbedObject.tag = "Untagged";

>>>>>>> MichaelBranch
    }
}
