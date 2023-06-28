using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public float speed = 10.0f;

    private float verticalRotation = 0.0f;

    void Update () {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        transform.parent.Rotate(Vector3.up * mouseX * mouseSensitivity * Time.deltaTime);

        verticalRotation += mouseY * mouseSensitivity * Time.deltaTime;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        float forwardSpeed = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float sidewaysSpeed = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.parent.Translate(Vector3.forward * forwardSpeed);
        transform.parent.Translate(Vector3.right * sidewaysSpeed);
    }
}
