using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBrilliantSphereController : MonoBehaviour {

    public float rotationSpeed, speed;

    private GameObject destination;

    // Use this for initialization
    void Start () {
        Invoke("DestroyBall", 8f);
	}
	
	// Update is called once per frame
	void Update () {
        if (destination != null)
        {
            transform.Translate(Vector3.forward * 0.02f * speed);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(destination.transform.position - transform.position), Time.deltaTime * rotationSpeed * 0.5f);
        }else Destroy(gameObject);
    }

    public void setDestination(GameObject destination)
    {
        this.destination = destination;
    }

    public void DestroyBall()
    {
        destination.GetComponent<RedBallController>().SetTreated(false);
        Destroy(gameObject);
    }
}
