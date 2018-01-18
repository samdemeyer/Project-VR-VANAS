using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckInput : MonoBehaviour {

	public InputField[] inputFields;

    public Text savedMessageStudent, savedMessageDocent, savedMessageMap;

    public Text StudentT, DocentT, MapT;

    //public Canvas FORM, CONTROL;
	private string nameStudent, nameDocent, pathToMap;

    public Canvas FORM, CONTROL, ERROR;

    // Use this for initialization
	void Start () {

		FORM.enabled = true;

        ERROR.enabled = false;

        CONTROL.enabled = false;
	}
	
    public void getIput()
    {
        FORM.enabled = false;

		CONTROL.enabled = true;

		foreach (InputField field in inputFields)
		{
			string s = PlayerPrefs.GetString(field.name);

			switch (field.name)
			{
				case "StudentName":
					nameStudent = s;
					Debug.Log(field.name + nameStudent);
                    StudentT.text = s;
					break;
				case "DocentName":
					nameDocent = s;
					Debug.Log(field.name + nameDocent);
                    DocentT.text =  s;
					break;
				case "MapPath":
					pathToMap = s;
					Debug.Log(field.name + pathToMap);
                    MapT.text =  s;
					break;
				default:
					Debug.Log("Nothing");
					break;
			}

			
		}
    }

    public void activateForm()
    {
        FORM.enabled = true;

        CONTROL.enabled = false;

        ERROR.enabled = false;

		savedMessageStudent.enabled = false;
		savedMessageDocent.enabled = false;
		savedMessageMap.enabled = false;
    }


	void Update () {
		
	}
}
