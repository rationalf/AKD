using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class KeiboardMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;
    private CharacterController charController;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        charController = GetComponent<CharacterController>();
    }

// Update is called once per frame
    void Update()
    {
        speed = 6.0f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed *= 3f;
        }
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        float dt = Time.deltaTime;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= dt;
        movement = transform.TransformDirection(movement);
        charController.Move(movement);
    }
}