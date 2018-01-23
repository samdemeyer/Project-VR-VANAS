using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class GenerateXMLOnStart : MonoBehaviour
{
    [SerializeField]
    //public Canvas ParentCanvas;
    //public GameObject PatientUIPrefab;
    public MedicalAppData medi = new MedicalAppData();
    private const string XMLFILE = "medidata.xml";

    //TODO: patient, cabinet, cabinetdrawer

    // Use this for initialization
    void Start()
    {
        //Write XML
        createPatientInfo();
        createDelivertyMethod();
        generateMedicines();
        generateScenario();

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
    void Update()
    {

    }

    private MedicalAppData readXml(string xmlFilePath)
    {
        MedicalAppData loaded;
        bool succes = MedicalAppData.ReadFromFile(xmlFilePath, out loaded);
        Debug.Log(succes);

        return loaded;
    }

    protected void createPatientInfo()
    {
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
        patient2.mID = 0;
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
    }

    protected void createDelivertyMethod()
    {

        DeliveryTool deliveryTool1 = new DeliveryTool(), deliveryTool2 = new DeliveryTool(), deliveryTool3 = new DeliveryTool();
        deliveryTool1.mID = 0;
        deliveryTool1.mName = "Oplossing";


        deliveryTool3.mID = 1;
        deliveryTool3.mName = "Spuit";

        //----------------------------------------------------------------//
        List<DeliveryTool> deliveryTools1 = new List<DeliveryTool>();
        List<DeliveryTool> deliveryTools3 = new List<DeliveryTool>();

        deliveryTools1.Add(deliveryTool1);

        deliveryTools3.Add(deliveryTool3);
        //----------------------------------------------------------------//

        DeliveryMethod deliveryMethod1 = new DeliveryMethod(), deliveryMethod3 = new DeliveryMethod();

        deliveryMethod1.mID = 0;
        deliveryMethod1.mName = "Oplossing in water";
        deliveryMethod1.mTools = deliveryTools1;


        deliveryMethod3.mID = 1;
        deliveryMethod3.mName = "Spuit";
        deliveryMethod3.mTools = deliveryTools3;

        medi.mMethods.Add(deliveryMethod1);
        medi.mMethods.Add(deliveryMethod3);

        medi.mTools.Add(deliveryTool1);
        medi.mTools.Add(deliveryTool3);
    }

    protected void generateMedicines()
    {
        Medicine med1 = new Medicine();
        med1.mID = 0;
        med1.mName = "Adrenaline";
        med1.mPackage = Package.bottle;
        med1.mPointsOfAttention = null;
        med1.mUnit = Unit.ml;
        med1.quantity = 100;

        medi.mMedicines.Add(med1);
        
    }

    protected void generateScenario()
    {
        Scenario scenario1 = new Scenario();
        scenario1.mDeliveryMethod = 1;
        scenario1.mID = 0;
        scenario1.mMedicineID = 0;
        scenario1.mName = "Scenario 1";
        scenario1.mPatientID = 0;
        scenario1.mCabinetID = 0;

        medi.mScenarios.Add(scenario1);

        GameObject.Find("VANAS_UI").GetComponent<SetPatientUI>().setScenarioText(medi.mPatients[2].mName,medi.mMethods[1].mName,medi.mMedicines[0].mName);
    }
}