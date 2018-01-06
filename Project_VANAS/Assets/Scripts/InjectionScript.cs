using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjectionScript : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "InjectablePosition")
        {
            Debug.Log("You'll inject the person");
        }
    }
}
