using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour {
    private List<GameObject> inventory = new List<GameObject>();
    public VRTK.VRTK_InteractGrab handHoldingItems;
    public Image buttonContainer;
    public Button buttonPrefab;
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
        
            GameObject newActiveObject = Instantiate(_gameobject);
            newActiveObject.transform.parent = gameObject.transform;
            newActiveObject.transform.position = handHoldingItems.transform.position;
            newActiveObject.name = createNameForNewItem(_gameobject);
            inventory.Add(newActiveObject);
            newActiveObject.SetActive(false);

            Button button = Instantiate(buttonPrefab, buttonContainer.transform);
            button.name = newActiveObject.name;
            button.onClick.AddListener(() => { findGameObject(newActiveObject.name); });
            button.onClick.AddListener(() => { setButtonStates(button); });
            button.transform.GetChild(0).GetComponent<Text>().text = newActiveObject.name;
            activateAllButtons();

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
        //deleteAllCurrentInGameItems();
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
    public void setButtonStates(Button _clickedButton)
    {
        for (int i = 0; i < buttonContainer.transform.childCount; i++)
        {
            
            if (buttonContainer.transform.GetChild(i).gameObject == _clickedButton.gameObject)
            {
                Debug.Log("set button states, button: " + buttonContainer.transform.GetChild(i).gameObject.name + "setactive");
                buttonContainer.transform.GetChild(i).GetComponent<Button>().interactable = false ;
                if (buttonContainer.transform.GetChild(i).gameObject.name != "HoldNothing")
                {
                    Destroy(buttonContainer.transform.GetChild(i).gameObject);
                }
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
            Debug.Log(buttonContainer.transform.GetChild(i).gameObject.name);
            buttonContainer.transform.GetChild(i).GetComponent<Button>().interactable = true;
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
}
