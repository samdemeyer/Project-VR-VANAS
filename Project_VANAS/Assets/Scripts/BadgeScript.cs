using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadgeScript : MonoBehaviour {

    // Personal information
    public string nameEmployee = "";
    public string job = "Nurse";

    // Vanaskast information
    public Canvas welcomeScreen;
    public Text nameText;
    public Text jobText;
    public Canvas screenUI;
    public Canvas patientSpecific;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "vanaskastScanner")
        {
            nameText.text = nameEmployee;
            jobText.text = job;

            screenUI.gameObject.SetActive(false);
            patientSpecific.gameObject.SetActive(false);

            welcomeScreen.gameObject.SetActive(true);
            StartCoroutine(bootSystemVanaskast());
        }
    }

    IEnumerator bootSystemVanaskast()
    {
        yield return new WaitForSeconds(3f);
        welcomeScreen.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        screenUI.gameObject.SetActive(true);
    }
}
