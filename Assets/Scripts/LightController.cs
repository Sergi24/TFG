using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Light>().enabled = false;
        InvokeRepeating("ParpadejarDeFormaAleatoria", 1, 1);
	}

    private void ParpadejarDeFormaAleatoria() {
        int probabilitat;
        if (gameObject.GetComponent<Light>().enabled) probabilitat = 2;
        else probabilitat = 4;
        if (Random.Range(0, probabilitat) == 0)
        {
            if (gameObject.GetComponent<Light>().enabled) gameObject.GetComponent<Light>().enabled = false;
            else gameObject.GetComponent<Light>().enabled = true;
        }
    }
}
