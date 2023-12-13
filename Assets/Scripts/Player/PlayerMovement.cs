using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
	//Audios
	[SerializeField] private AudioSource[] audio_movement;


	public Camera playerCamera;
	public float walkSpeed = 6f;
	public float runSpeed = 12f;
	public float jumpPower = 7f;
	public float gravity = 10f;

	public float lookSpeed = 2f;
	public float lookXLimit = 45f;

	Vector3 moveDirection = Vector3.zero;
	float rotationX = 0;

	public bool canMove = true;

	CharacterController characterController;



	private void Start()
    {
        characterController = GetComponent<CharacterController>();
		Cursor.lockState = CursorLockMode.Locked;
		
    }

    private void Update()
    {
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		Vector3 right = transform.TransformDirection(Vector3.right);

		bool isRunning = Input.GetKey(KeyCode.LeftShift);

		float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;

		float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;

		bool isMoving = Mathf.Abs(curSpeedX) > 0.1f || Mathf.Abs(curSpeedY) > 0.1f;

		//While player is moving, sound must be playing
		if (isMoving)
		{
			if (isRunning && !audio_movement[0].isPlaying)
			{
				Debug.Log("Running: Starting audio_movement[1]");
				audio_movement[1].Play();
			}
			else if (isRunning && audio_movement[0].isPlaying)
			{
				Debug.Log("Running: Stopping audio_movement[0] and starting audio_movement[1]");
				audio_movement[0].Stop();
				audio_movement[1].Play();
			}
			else if (!isRunning && !audio_movement[0].isPlaying)
			{
				Debug.Log("Walking: Starting audio_movement[0]");
				audio_movement[0].Play();
			}
		}
		else
		{
			//Debug.Log("Stopping all audio");
			audio_movement[0].Stop();
			audio_movement[1].Stop();
		}





		float movementDirectionY = moveDirection.y;


		moveDirection = (forward * curSpeedX) + (right * curSpeedY);


		if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
			moveDirection.y = jumpPower;
        }
		else
        {
			moveDirection.y = movementDirectionY;
        }
		if(!characterController.isGrounded)
        {
			moveDirection.y -= gravity * Time.deltaTime;
        }

		characterController.Move(moveDirection * Time.deltaTime);
        if (canMove)
        {
			
			rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
			rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
			playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
			transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}