using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveInput : MonoBehaviour {

	public InputField[] inputFields;

    public Text savedMessageStudent, savedMessageDocent, savedMessageMap;

	void Start()
	{
        savedMessageStudent.enabled = false;
        savedMessageDocent.enabled = false;
        savedMessageMap.enabled = false;

		foreach (InputField field in inputFields)
		{
			var se = new InputField.SubmitEvent();

				se.AddListener(delegate { SubmitText(field.name, field.text);});


			field.onEndEdit = se;
		}


	}

	public void SubmitText(string prefKey, string prefVal)
	{
        // nog te fixen
        if(prefVal != "\r" || prefVal != " ")
        {
			Debug.Log("Saved " + prefVal + " to " + prefKey);
			// store the typed text of the respective input field
			PlayerPrefs.SetString(prefKey, prefVal);

            switch (prefKey)
			{
				case "StudentName":
                    savedMessageStudent.enabled = true;
					break;
				case "DocentName":
                    savedMessageDocent.enabled = true;
					break;
				case "MapPath":
                    savedMessageMap.enabled = true;
					break;
				default:

					break;
			}

        }

        else
        {Debug.Log("Empty"); }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
