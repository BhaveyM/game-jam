using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(4, 0, 0);
        if (Input.GetKey(KeyCode.Space))
            Physics.gravity = new Vector3(0, 9.81f, 0);

        if (Input.GetKey(KeyCode.A))
            GetComponent<Rigidbody>().velocity = new Vector3(4, 0, 2);
        if (Input.GetKey(KeyCode.D))
            GetComponent<Rigidbody>().velocity = new Vector3(4, 0, -2);
    }
}
