using UnityEngine;
using System.Collections;


public class BigBroMovement : MonoBehaviour {
	//Components
	//private Camera _playerCamera; 
	private CharacterController _controller;

	//Variables
	private Vector3 _input;
	private Vector3 _movement;
	private Quaternion _targetRotation;

	[SerializeField]
	private float _walkSpeed = 100;
	[SerializeField]
	float gravity = 20.0f;
	[SerializeField]
	float jumpHeight = 8.0f;
	
	void Start () {
		_controller = GetComponent<CharacterController>();

	}
	
	void Update () {

		PlayerMovement ();

	}
	
	void PlayerMovement(){

		if (_controller.isGrounded) {
			_input = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
			_movement = _input;
			_movement *= (Mathf.Abs (_input.x) == 1 && Mathf.Abs (_input.z) == 1) ? 0.7f : 1;
			_movement = transform.TransformDirection(_movement);
			_movement *= _walkSpeed;

			if (Input.GetButton ("Jump")) {
				_movement.y = jumpHeight;
			}
		}
		_movement.y -= gravity * Time.deltaTime;
		_controller.Move (_movement * Time.deltaTime);
	}

}
