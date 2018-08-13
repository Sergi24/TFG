using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

public class MainCameraController : MonoBehaviour {

    private bool thresholdReductionActived;

	// Use this for initialization
	void Start () {
        Invoke("FinalizeScene", 23);
        thresholdReductionActived = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (thresholdReductionActived)
        {
            gameObject.GetComponent<Bloom>().bloomThreshold -= 0.01f;
            if (gameObject.GetComponent<Bloom>().bloomThreshold <= 0.1f) SceneManager.LoadScene("Night");
        }
	}

    void FinalizeScene()
    {
        thresholdReductionActived = true;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
