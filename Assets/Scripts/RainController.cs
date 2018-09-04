using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        foreach (ParticleEmitter pe in gameObject.GetComponentsInChildren<ParticleEmitter>())
        {
            pe.enabled = false;
        }
        Invoke("ActivarPluja", 4f);
	}

    public void ActivarPluja()
    {
        foreach(ParticleEmitter pe in gameObject.GetComponentsInChildren<ParticleEmitter>()){
            pe.enabled = true;
        }
        gameObject.GetComponent<AudioSource>().enabled = true;
    }
	
}
