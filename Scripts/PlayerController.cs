using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	[SerializeField]
	public float speed;
	[SerializeField]
	public float gravityScale;
	public CharacterController controller;
	private float mouseX, mouseY;
	[SerializeField]
	public float RotationSpeed = 1;
	public float turnSmoothTime = 0.1f;
	public float turnSmoothVelocity;
	private Vector3 direction;
	public Transform Target, Player;

	private void Start()
	{
		//adds character controller to script
		controller = GetComponent<CharacterController>();
		//hides mouse cursor on screen
		Cursor.visible = false;
		//Cursor.lockState = CursorLockMode.Locked;

	}

	// Update is called once per frame
	void Update()
	{
		//direction = new Vector3(Input.GetAxis("Horizontal") * speed,direction.y, Input.GetAxis("Vertical") * speed);
		//Controls & moves camera
		//CamControl();

		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

		if (direction.magnitude >= 0.1f)
        {
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Target.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
			transform.rotation = Quaternion.Euler(0f, angle, 0f);

			Vector3 move = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
			controller.Move(move.normalized * speed * Time.deltaTime);
        }
		//direction.x = Input.GetAxis("Horizontal") * speed;
		//with just "=" the character was floating in the air
		//"-=" solved that issue
		//direction.y -= Input.GetAxis("Vertical") * speed;
		//Allows character to move
		//controller.Move(direction * Time.deltaTime);
		// Apply Gravity
		//direction.y = direction.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
 
		 // Y movement
		/*if (controller.isGrounded)
		{
			// Jump
			if (Input.GetButtonDown("Jump"))
			{
				direction.y = jumpForce; // Jump
			}

		}
		*/
	}
		

	/*private void CamControl()
    {
		//Controls horizontal movement of camera
		mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
		//Controls vertical movement of camera
		mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
		//prevents camera from flipping on the Y axis
		mouseY = Mathf.Clamp(mouseY, -35, 60);
		//Camera focused on target
		transform.LookAt(Target);
		//Controls rotation of camera & player separately
		Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
		Player.rotation = Quaternion.Euler(0, mouseX, 0);
			
    }*/

}
