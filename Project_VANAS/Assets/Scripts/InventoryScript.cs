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
        

    }
    public void emptyHand()
    {
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
    }
}
