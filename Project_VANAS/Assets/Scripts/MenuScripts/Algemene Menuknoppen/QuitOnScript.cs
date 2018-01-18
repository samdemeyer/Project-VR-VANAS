using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sam

public class QuitOnScript : MonoBehaviour {
   

public void Quit()
    {
       
#if UNITY_EDITOR //if scene is opened in editor;
        UnityEditor.EditorApplication.isPlaying = false;

#else //if scene is build
        Application.Quit();

#endif
    }
}
