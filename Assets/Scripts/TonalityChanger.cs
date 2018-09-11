using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonalityChanger : MonoBehaviour {
    public int numTonalitat;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<MusicController>().SetTonalitat(numTonalitat);
        }
    }
}
