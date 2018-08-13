using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float velocitat, velocitatRotacio;
    public GameObject leftInstantiator, rightInstantiator, blueBrilliantSphere;

    private Camera playerCamera;
    private bool leftInstantiatorActived = true;

    private void Start()
    {
        playerCamera = gameObject.GetComponentInChildren<Camera>();
    }

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * velocitatRotacio * 75.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * velocitat * 2.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 objectHit = hit.point;
            if (hit.transform.tag.Equals("RedBall") && Input.GetKeyDown(KeyCode.Mouse0) && !hit.transform.gameObject.GetComponent<RedBallController>().GetTreated())
            {
                Transform instantiator;
                if (leftInstantiatorActived) instantiator = leftInstantiator.transform;
                else instantiator = rightInstantiator.transform;
                leftInstantiatorActived = !leftInstantiatorActived;
                GameObject sphere = Instantiate(blueBrilliantSphere, instantiator.position, instantiator.rotation);
                sphere.GetComponent<BlueBrilliantSphereController>().setDestination(hit.transform.gameObject);
                hit.transform.gameObject.GetComponent<RedBallController>().SetTreated(true);
            }

        }
    }
}
