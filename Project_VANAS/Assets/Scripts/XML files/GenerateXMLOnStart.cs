using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class GenerateXMLOnStart : MonoBehaviour {
    [SerializeField]
    //public Canvas ParentCanvas;
    //public GameObject PatientUIPrefab;
    protected MedicalAppData medi = new MedicalAppData();
    private const string XMLFILE = "medidata.xml";

    //TODO: patient, cabinet, cabinetdrawer
    
    // Use this for initialization
    void Start ()
    {
        //Write XML
        Patient patient1 = new Patient(), patient2 = new Patient(), patient3 = new Patient();
        patient1.mAge = 25;
        patient1.mAllergies.Add("none");
        patient1.mID = 2;
        patient1.mName = "Sam De Meyer";
        patient1.mSex = Sex.male;
        patient1.mType = PatientType.adult;
        patient1.mWeight = 78;

        patient2.mAge = 80;
        patient2.mAllergies.Add("none");
        patient2.mID = 3;
        patient2.mName = "Patricia Beets";
        patient2.mSex = Sex.female;
        patient2.mType = PatientType.senior;
        patient2.mWeight = 65;

        patient3.mAge = 14;
        patient3.mAllergies.Add("none");
        patient3.mID = 1;
        patient3.mName = "William Peeters";
        patient3.mSex = Sex.X;
        patient3.mType = PatientType.child;
        patient3.mWeight = 40;

        medi.mPatients.Add(patient3);
        medi.mPatients.Add(patient1);
        medi.mPatients.Add(patient2);
        

        /*CabinetDrawer cd = new CabinetDrawer();
        cd.mID = 0;
        cd.mIsLocked = true;  */

        //  medi.mCabinets.Add(new Cabinet());



        MedicalAppData.WriteToFile(ref medi, XMLFILE);

        //Load XML
        MedicalAppData loaded;
        loaded = readXml(XMLFILE);

        GameObject vanas_UI = GameObject.Find("VANAS_UI");

        vanas_UI.GetComponent<SetPatientUI>()._loaded = loaded;
        vanas_UI.GetComponent<SetPatientUI>().setButtonNames();
        vanas_UI.GetComponent<SetPatientUI>().setDoorInfo();

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private MedicalAppData readXml(string xmlFilePath)
    {
        MedicalAppData loaded;
        bool succes = MedicalAppData.ReadFromFile(xmlFilePath, out loaded);
        Debug.Log(succes);

        return loaded;
    }
}
