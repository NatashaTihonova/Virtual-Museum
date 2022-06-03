using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.X))
            transform.Rotate(-Vector3.right * rotationSpeed * Time.deltaTime);
    }
}
