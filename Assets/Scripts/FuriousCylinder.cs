using UnityEngine;
using System.Collections;

public class FuriousCylinder : MonoBehaviour
{
    public float rotationSpeed, speed, upVelocity;
    public GameObject redBallInstantiator;

    private bool up, actived;
    private AudioSource asource;
    // Use this for initialization
    void Start()
    {
        up = false;
        actived = false;
        asource = gameObject.GetComponent<AudioSource>();
        /*foreach (GameObject canon in canons)
        {
            canon.GetComponent<BoxCollider>().enabled = false;
        }*/
        foreach (Collider collider in gameObject.GetComponentsInChildren<Collider>())
        {
            collider.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameObject.Find("Player").transform.position-transform.position).magnitude < 4 && !actived)
        {
            float angle = Quaternion.Angle(GameObject.Find("Player").transform.rotation, transform.rotation);
            //Debug.Log(angle);
            if (angle > 170 && angle < 190) SetActiveFuriousCylinder();
        }
        if (up)
        {
            transform.Translate(Vector3.up * 0.5f * upVelocity * Time.deltaTime);
            if (transform.position.y > 1.55f)
            {
                foreach (Collider collider in gameObject.GetComponentsInChildren<Collider>())
                {
                    collider.enabled = true;
                }
                up = false;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                redBallInstantiator.GetComponent<RedBallInstantiator>().ActiveThrow();
            }
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(GameObject.Find("Player").transform.position - transform.position), Time.deltaTime * rotationSpeed * 0.3f);
    }

    private void SetActiveFuriousCylinder()
    {
        Light[] lights = gameObject.GetComponentsInChildren<Light>();
        foreach (Light light in lights)
        {
            light.enabled = true;
            light.color = Color.red;
        }
        up = true;
        actived = true;
        asource.Play();
    }
}
