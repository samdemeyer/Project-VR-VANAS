using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPatientUI : MonoBehaviour {
    // Use this for initialization
    protected string pName, pType, pSex, pAllergie;
    protected int pAge, pWeight;
    public Text uiName, uiAge, uiType, uiWeight, uiSex, uiAllergie;
    public Text tabletName, tabletAge, tabletType, tabletWeight, tabletSex, tabletAllergie;
    public Text btn1T, btn2T, btn3T;
    public Text d1Name, d1Age, d1Type, d1Weight, d1Sex, d1Allergie;//child
    public Text d2Name, d2Age, d2Type, d2Weight, d2Sex, d2Allergie;//adult
    public Text d3Name, d3Age, d3Type, d3Weight, d3Sex, d3Allergie;//old

    public Text sPatient, sAdministration, sMed;//text on scenario canvas

    public Text tName, tAge, tType, tWeight, tSex, tAllergie;//selected patient info
    public GameObject panel1, panel2, panel3, MenuPanel;

    public Button button1, button2, button3;
    public MedicalAppData _loaded;
    public void getPatientName(Button _pressedButton)
    {
        getPatientInfo(_pressedButton.gameObject.name);
        //Debug.Log("Child text is " + _pressedButton.transform.GetChild(0).GetComponent<Text>().text);
        //Debug.Log("Button name is " + _pressedButton.gameObject.name);
        SetUI();
        GameObject.Find("medicijnkast").GetComponent<VANASScript>().chooseRandomDrawer();
    }
    private void Start()
    {
        //XMLController
        _loaded = GameObject.Find("XMLController").GetComponent<GenerateXMLOnStart>().medi;
        setButtonNames();
    }
    protected void SetUI()
    {
        uiName.text = pName;
        uiAge.text = pAge.ToString();
        uiWeight.text = pWeight.ToString();
        uiAllergie.text = pAllergie;
        uiType.text = pType;
        uiSex.text = pSex;

        tabletName.text = pName;
        tabletAge.text = pAge.ToString();
        tabletWeight.text = pWeight.ToString();
        tabletAllergie.text = pAllergie;
        tabletType.text = pType;
        tabletSex.text = pSex;

    }
    public void setButtonNames()
    {
        button1.name = _loaded.mPatients[0].mName;
        btn1T.text = _loaded.mPatients[0].mName;

        button2.name = _loaded.mPatients[1].mName;
        btn2T.text = _loaded.mPatients[1].mName;

        button3.name = _loaded.mPatients[2].mName;
        btn3T.text = _loaded.mPatients[2].mName;
    }
    private void getPatientInfo(string _name)
    {
        for (int i = 0; i < _loaded.mPatients.Count; i++)
        {
            if (_loaded.mPatients[i].mName == _name)
            {
                pName = _loaded.mPatients[i].mName;
                pAge = _loaded.mPatients[i].mAge;
                pWeight = _loaded.mPatients[i].mWeight;
                pSex = _loaded.mPatients[i].mSex.ToString();
                pType = _loaded.mPatients[i].mType.ToString();
                for (int b = 0; b < _loaded.mPatients[i].mAllergies.Count; b++)
                {
                    pAllergie = _loaded.mPatients[i].mAllergies[b] + "\n";
                }
                
            }
        }
    }
    public void setDoorInfo()
    {
        d1Name.text = _loaded.mPatients[0].mName;
        d1Age.text = _loaded.mPatients[0].mAge.ToString();
        d1Sex.text = _loaded.mPatients[0].mSex.ToString();
        d1Type.text = _loaded.mPatients[0].mType.ToString();
        d1Weight.text = _loaded.mPatients[0].mWeight.ToString();
        for (int i = 0; i < _loaded.mPatients[0].mAllergies.Count; i++)
        {
            d1Allergie.text = _loaded.mPatients[0].mAllergies[i] + "\n";
        }
        d2Name.text = _loaded.mPatients[1].mName;
        d2Age.text = _loaded.mPatients[1].mAge.ToString();
        d2Sex.text = _loaded.mPatients[1].mSex.ToString();
        d2Type.text = _loaded.mPatients[1].mType.ToString();
        d2Weight.text = _loaded.mPatients[1].mWeight.ToString();
        for (int i = 0; i < _loaded.mPatients[1].mAllergies.Count; i++)
        {
            d2Allergie.text = _loaded.mPatients[1].mAllergies[i] + "\n";
        }
        d3Name.text = _loaded.mPatients[2].mName;
        d3Age.text = _loaded.mPatients[2].mAge.ToString();
        d3Sex.text = _loaded.mPatients[2].mSex.ToString();
        d3Type.text = _loaded.mPatients[2].mType.ToString();
        d3Weight.text = _loaded.mPatients[2].mWeight.ToString();
        for (int i = 0; i < _loaded.mPatients[2].mAllergies.Count; i++)
        {
            d3Allergie.text = _loaded.mPatients[2].mAllergies[i] + "\n";
        }
    }
    public void setSelectedPatientsInfo(int _patientIndex)
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        MenuPanel.SetActive(false);
        panel3.SetActive(true);

        tName.text = _loaded.mPatients[_patientIndex - 1].mName;
        tAge.text = _loaded.mPatients[_patientIndex - 1].mAge.ToString();
        tType.text = _loaded.mPatients[_patientIndex - 1].mType.ToString();
        tWeight.text = _loaded.mPatients[_patientIndex - 1].mWeight.ToString();
        tSex.text = _loaded.mPatients[_patientIndex - 1].mSex.ToString();
        for (int b = 0; b < _loaded.mPatients[_patientIndex-1].mAllergies.Count; b++)
        {
            tAllergie.text = _loaded.mPatients[_patientIndex - 1].mAllergies[b] + "\n";
        }

    }
    public void setScenarioText(string patient, string administration, string med)
    {
        sPatient.text = patient;
        sAdministration.text = administration;
        sMed.text = med;
    }
}
