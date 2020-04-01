using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    float xAxisValue;
    float zAxisValue;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Translate();
        Rotate();
    }

    private void Translate()
    {
        xAxisValue = Input.GetAxis("Horizontal");
        zAxisValue = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(xAxisValue, 0.0f, zAxisValue));
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, 40 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(-Vector3.up, 40 * Time.deltaTime);
        }
    }
}
