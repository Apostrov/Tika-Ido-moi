using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class HeroInput : MonoBehaviour
{
    public float speed = 6.0f;
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var movement = Move();
        _characterController.Move(movement);
    }

    private Vector3 Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaY = Input.GetAxis("Vertical") * speed;

        var movement = new Vector3(deltaX, deltaY, 0);
        movement = Vector3.ClampMagnitude(movement, speed) * Time.deltaTime;
        movement = transform.TransformDirection(movement);
        return movement;
    }
}