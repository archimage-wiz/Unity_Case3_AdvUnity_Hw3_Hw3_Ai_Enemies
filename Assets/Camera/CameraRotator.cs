using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField, Tooltip("Camera rotation speed float"), Range(0.1f, 333)]
    private float camera_rotation_speed = 100;
    private float input_status;

    void Update()
    {
        input_status = SceneGameContainer.input_x.InputMap.CameraRotation.ReadValue<float>();

        if (input_status > 0) { transform.Rotate(0, camera_rotation_speed * Time.deltaTime, 0); }
        if (input_status < 0) { transform.Rotate(0, -camera_rotation_speed * Time.deltaTime, 0); }

    }

}
