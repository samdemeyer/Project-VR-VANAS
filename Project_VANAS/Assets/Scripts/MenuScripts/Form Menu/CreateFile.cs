using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System.IO;
using System.Collections;

public class CreateFile : MonoBehaviour {

    public Text ErrorMessage;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void writeFile()
    {
        string stateSimulation = PlayerPrefs.GetString("SimulatieType");
        string studentN = PlayerPrefs.GetString("StudentName");
        string docentN = PlayerPrefs.GetString("DocentName");
        string map = PlayerPrefs.GetString("MapPath");

        string fileName = stateSimulation + "_" + studentN;

        string pathToFile = Path.Combine(map, fileName);

        Debug.Log(stateSimulation + studentN + " " + docentN + " " + map + " " + System.DateTime.Now);


    }
}
