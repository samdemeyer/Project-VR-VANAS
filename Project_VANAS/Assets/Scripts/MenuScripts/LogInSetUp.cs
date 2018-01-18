using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class LogInSetUp : MonoBehaviour {

    public Text subTitle;

    // Use this for initialization
    void Start()
    {


        string stateSimulation = PlayerPrefs.GetString("SimulatieType");

        subTitle.text += " " + stateSimulation;

    }
	// Update is called once per frame
	void Update () {


	}
}
