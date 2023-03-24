using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotator : MonoBehaviour
{
    [SerializeField, Tooltip("Camera rotation speed float"), Range(0.1f, 333)]
    private float camera_move_speed = 10;
    private Vector2 input_status;

    void Update()
    {
        input_status = SceneGameContainer.input_x.InputMap.CameraRotation.ReadValue<Vector2>();

        if (input_status.x > 0) { transform.position += camera_move_speed * Time.deltaTime * transform.right; }
        if (input_status.x < 0) { transform.position += camera_move_speed * Time.deltaTime * -transform.right; }
        if (input_status.y > 0) { transform.position += camera_move_speed * Time.deltaTime * transform.forward; }
        if (input_status.y < 0) { transform.position += camera_move_speed * Time.deltaTime * -transform.forward; }

        if (Mouse.current.leftButton.isPressed == true || Mouse.current.rightButton.isPressed == true)
        {
            // TODO Fix cursore
            transform.Rotate(-Mouse.current.delta.value.y * camera_move_speed * Time.deltaTime, Mouse.current.delta.value.x * camera_move_speed * Time.deltaTime, 0f);
            transform.Rotate(0, 0, -transform.eulerAngles.z);
        }

    }

}
