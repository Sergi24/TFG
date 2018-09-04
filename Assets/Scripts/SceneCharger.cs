using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCharger : MonoBehaviour {
    public string scene;

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(scene);
    }
}
