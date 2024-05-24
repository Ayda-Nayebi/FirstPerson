using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookController : MonoBehaviour
{
    public static PlayerLookController Instance;

    public Camera Camera;

    private float xRotation = 0f;

    public float xSensivity = 30f;
    private float ySensivity = 30f;


    private void Start()
    {
        Instance = this;
    }

    public void LookProccessor(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        // calculate camera rotation up & down
        xRotation -= (mouseY * Time.deltaTime) * ySensivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        //apply rotation to camera
        Camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //rotate player to left & right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensivity);
    }

}
