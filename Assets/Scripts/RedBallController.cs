using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallController : MonoBehaviour {

    public float rotationSpeed, speed;
    public GameObject redBallExplosion;

    private bool treated;
    private void Start()
    {
        Destroy(gameObject, 20f);    
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.forward * 0.02f * speed);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(GameObject.Find("Player").transform.position - transform.position), Time.deltaTime * rotationSpeed * 0.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.tag.Equals("FuriousCylinder"))
        {
            Instantiate(redBallExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public bool GetTreated()
    {
        return treated;
    }

    public void SetTreated(bool treated)
    {
        this.treated = treated;
    }
}
