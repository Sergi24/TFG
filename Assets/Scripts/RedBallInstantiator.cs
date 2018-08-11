using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallInstantiator : MonoBehaviour {

    public GameObject redBall;

    public void ActiveThrow()
    { 
        InvokeRepeating("ThrowBall", 1, 10);
    }

    public void ThrowBall()
    {
        Instantiate(redBall, transform.position, transform.rotation);
    }
}
