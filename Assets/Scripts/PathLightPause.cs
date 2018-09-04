using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathLightPause : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Player").GetComponent<MusicController>().SetMusicaPausada(false);
        //GameObject.Find("Rain").GetComponent<RainController>().ActivarPluja();
        //Invoke("BaixarVolumPluja", 0.3f);
    }

    private void BaixarVolumPluja()
    {
        GameObject.Find("Rain").GetComponent<AudioSource>().volume /= 2;
    }
}
