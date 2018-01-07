using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class CheckSimulation : MonoBehaviour {

	public Button yourButton;

	void Start()
	{        
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(CheckOnClick);
	}

	void CheckOnClick()
	{
		Debug.Log("You have clicked the button!");

		string s = yourButton.name;

		switch (s)
		{
			case "Examen":
				Debug.Log(s);
				PlayerPrefs.SetString("SimulatieType", s);
                break;
            case "Sessie":
				Debug.Log(s);
                PlayerPrefs.SetString("SimulatieType", "Oefensessie");
				break;
			default:
				Debug.Log("No Choice");
				break;
		}
	}


}
