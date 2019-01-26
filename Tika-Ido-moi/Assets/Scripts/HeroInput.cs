using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class HeroInput : MonoBehaviour {

	public float speed = 6.0f;
	public float gravity = -9.8f;
	private CharacterController _characterController;

	private void Start () {
		_characterController = GetComponent<CharacterController>();
	}

	private void Update () {
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;

		var movement = new Vector3(deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude(movement, speed) * Time.deltaTime;
		movement = transform.TransformDirection(movement);
		movement.y = gravity;
		_characterController.Move(movement);
	}
}
