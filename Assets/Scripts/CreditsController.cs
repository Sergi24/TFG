using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour {

    private void Start()
    {
        Transform transform = gameObject.GetComponent<RectTransform>().transform;
    }

    // Update is called once per frame
    void Update () {
        transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z), transform.rotation);
	}
}
