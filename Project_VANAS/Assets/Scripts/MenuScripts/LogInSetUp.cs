using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class LogInSetUp : MonoBehaviour {

    public Text subTitle;

    public InputField[] inputFields;
	// Use this for initialization
	void Start () {


            inputFields[0] = gameObject.GetComponent<InputField>();

			//var se = new InputField.SubmitEvent();
			//se.AddListener(SubmitName);

			//inputFields[0].text.onEndEdit = se;
       // inputFields[0].onEndEdit.AddListener(SubmitName);

		string stateSimulation = PlayerPrefs.GetString("SimulatieType");

        subTitle.text += " " + stateSimulation;



		//or simply use the line below, 
		//input.onEndEdit.AddListener(SubmitName);  // This also works
	}

	private void SubmitName(string arg0)
	{
		Debug.Log(arg0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
