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
        if (Input.GetKey(KeyCode.P))
        {
            Debug.Log("test");
            //inventory[0].GetComponent<VRTK.VRTK_InteractableObject>().Grabbed(handHoldingItems);
            //inventory[0].GetComponent<VRTK.VRTK_InteractableObject>().AddTrackPoint(handHoldingItems.gam);
            //inventory[0].GetComponent<VRTK.VRTK_InteractableObject>().StartUsing(inventory[0]);
            //inventory[0].GetComponent<VRTK.VRTK_InteractableObject>().IsGrabbed();
            //inventory[0].SetActive(true);
            //handHoldingItems.InitGrabbedObject(inventory[0].gameObject);
            //handHoldingItems.GetComponent<VRTK.VRTK_InteractGrab>().PerformGrabAttempt();
        }
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
        _gameobject.transform.parent = gameObject.transform;
        inventory.Add(_gameobject);

        Button button = Instantiate(buttonPrefab);
        button.transform.SetParent(buttonContainer.transform);
        button.onClick.AddListener(() => { findGameObject(_gameobject.name); });
        button.transform.GetChild(0).GetComponent<Text>().text = _gameobject.name;
    }
    public void deleteItemFromInventory(GameObject _gameobject)
    {
        //inventory.Remove(_gameobject);
        Destroy(_gameobject);
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
        Debug.Log(_activeObject.name);
        _activeObject.SetActive(true);
        _activeObject.transform.parent = handHoldingItems.transform;
        _activeObject.transform.position = handHoldingItems.transform.position;
        

    }
    public void emptyHand()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            inventory[i].SetActive(false);
        }
    }
}
