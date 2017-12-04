using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPatientUI : MonoBehaviour {
    protected string patientName;
    protected string patientsNeeds;
    protected int patientsAge;
    protected int patientsWeight;
    protected int patientsLength;
    // Use this for initialization

    public Text uiName, uiNeeds, uiAge, uiWeight, uiLength;
    public void getPatientName(Button _pressedButton)
    {
        getPatientInfo(_pressedButton.gameObject.name);
        //Debug.Log("Child text is " + _pressedButton.transform.GetChild(0).GetComponent<Text>().text);
        //Debug.Log("Button name is " + _pressedButton.gameObject.name);
        SetUI();
        GameObject.Find("medicijnkast").GetComponent<VANASScript>().chooseRandomDrawer();
    }
    protected void SetUI()
    {
        uiName.text = patientName;
        uiNeeds.text = patientsNeeds;
        uiAge.text = patientsAge.ToString();
        uiWeight.text = patientsWeight.ToString();
        uiLength.text = patientsLength.ToString();

    }
    private void getPatientInfo(string _name)
    {
        patientName = _name;
        switch (_name)
        {
            case "Sam De Meyer":
                patientsNeeds = "Morfine";
                patientsAge = 20;
                patientsLength = 182;
                patientsWeight = 78;
                break;
            case "Margo Hiel":
                patientsNeeds = "Dafalgan";
                patientsAge = 18;
                patientsLength = 172;
                patientsWeight = 65;
                break;
            case "Ignace Geluykens":
                patientsNeeds = "Nurofen";
                patientsAge = 16;
                patientsLength = 170;
                patientsWeight = 88;
                break;
            default:
                break;
        }
    }
}
