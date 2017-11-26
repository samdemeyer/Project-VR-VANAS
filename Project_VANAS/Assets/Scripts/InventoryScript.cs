using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour {
    private List<GameObject> inventory = new List<GameObject>();
    public GameObject handHoldingItems;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
    public void addItemToInventory(GameObject _gameobject)
    {
        _gameobject.transform.parent = gameObject.transform;
        inventory.Add(_gameobject);
    }
    public void deleteItemFromInventory(GameObject _gameobject)
    {
        inventory.Remove(_gameobject);
        Destroy(_gameobject);
    }
    public List<GameObject> returnInventory()
    {
        return inventory;
    }
}
