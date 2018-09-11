using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCharger : MonoBehaviour {
    public string scene;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gameObject.GetComponent<AudioSource>().Play();
            Invoke("ChangeScene", 2f);
            collision.gameObject.GetComponent<MusicController>().SetMusicaPausada(true);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            gameObject.GetComponent<AudioSource>().Play();
            Invoke("ChangeScene", 2f);
            collider.gameObject.GetComponent<MusicController>().SetMusicaPausada(true);
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(scene);
    }
}
