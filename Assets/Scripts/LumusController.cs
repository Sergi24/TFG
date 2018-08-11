using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumusController : MonoBehaviour {

    public float rotationSpeed, speed;
    public GameObject destination;

    private bool lightEnabled;

    // Use this for initialization
    void Start () {
        InvokeRepeating("EnableLight", 3, 3);
        lightEnabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * 0.02f * speed);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(destination.transform.position - transform.position), Time.deltaTime * rotationSpeed * 0.3f);
    }

    void EnableLight()
    {
        lightEnabled = !lightEnabled;
        gameObject.GetComponentInChildren<Light>().enabled = lightEnabled;
        gameObject.GetComponent<MeshRenderer>().enabled = lightEnabled;
    }
}
