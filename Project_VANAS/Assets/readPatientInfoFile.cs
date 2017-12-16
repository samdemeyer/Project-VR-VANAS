using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class readPatientInfoFile : MonoBehaviour {

    public Text[] patientDataHolders;
    public string[] patientData = new string[6];
    public int currentDataLine = 0;
    public string currentRoom;

    private void Start()
    {
        WritePatientData();
    }

    void WritePatientData()
    {
        string destination = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string patient1 = Path.Combine(destination, "patient1.txt");
        string patient2 = Path.Combine(destination, "patient2.txt");
        string patient3 = Path.Combine(destination, "patient3.txt");

        Debug.Log("Writing to: " + destination);

        StreamWriter outputStream = File.CreateText(patient2);
        outputStream.WriteLine("Michael Bellekens");
        outputStream.WriteLine("21");
        outputStream.WriteLine("Volwassen");
        outputStream.WriteLine("70");
        outputStream.WriteLine("Man");
        outputStream.WriteLine("Geen");
        outputStream.Close();

        outputStream = File.CreateText(patient3);
        outputStream.WriteLine("Patricia Beets");
        outputStream.WriteLine("80");
        outputStream.WriteLine("Bejaard");
        outputStream.WriteLine("65");
        outputStream.WriteLine("Vrouw");
        outputStream.WriteLine("Geen");
        outputStream.Close();

        outputStream = File.CreateText(patient1);
        outputStream.WriteLine("William Peeters");
        outputStream.WriteLine("14");
        outputStream.WriteLine("Kind");
        outputStream.WriteLine("40");
        outputStream.WriteLine("Man");
        outputStream.WriteLine("Geen");
        outputStream.Close();
    }

    public void ReadPatientData()
    {
        string sourcepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string myFile = null;

        switch (currentRoom)
        {
            case "patient1":
                myFile = Path.Combine(sourcepath, "patient1.txt");
                break;
            case "patient2":
                myFile = Path.Combine(sourcepath, "patient2.txt");
                break;
            case "patient3":
                myFile = Path.Combine(sourcepath, "patient3.txt");
                break;
            default:
                return;
        }

        StreamReader inputStream = null;
        
        try
        {
            inputStream = File.OpenText(myFile);
            string line;
            currentDataLine = 0;

            while (currentDataLine < 6)
            {
                line = inputStream.ReadLine();
                patientData[currentDataLine] = line;
                Debug.Log(currentDataLine + ": " + line);
                currentDataLine++;
            }
        }
        catch (FileNotFoundException ex)
        {
            Debug.Log("Bestand niet gevonden!");
            Debug.Log(ex);
        }
        finally
        {
            if (inputStream != null)
            {
                inputStream.Close();
            }
        }

        for (int i = 0; i < patientDataHolders.Length; i++)
        {
            patientDataHolders[i].text = patientData[i];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("patientRoom1"))
        {
            currentRoom = "patient1";
        }
        else if (other.CompareTag("patientRoom2"))
        {
            currentRoom = "patient2";
        }
        else if (other.CompareTag("patientRoom3"))
        {
            currentRoom = "patient3";
        }
    }
}
