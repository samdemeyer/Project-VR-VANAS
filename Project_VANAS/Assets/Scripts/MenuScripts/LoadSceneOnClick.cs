using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LoadSceneOnClick : MonoBehaviour
{
    //public string[] optionsSimulation;

	public void LoadByIndex(int sceneIndex)
	{
		SceneManager.LoadScene(sceneIndex);

        // setUp student clearen
        if(sceneIndex == 0 || sceneIndex == 1)
        {
            PlayerPrefs.DeleteAll();
        }
	}


}
