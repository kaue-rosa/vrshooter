using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

	private Vector2 _mouseAbsolute;
	private Vector2 _smoothMouse;

	[SerializeField] private Vector2 clampInDegrees = new Vector2(360, 180);
	[SerializeField] private bool lockCursor;
	[SerializeField] private Vector2 sensitivity = new Vector2(2, 2);
	[SerializeField] private Vector2 smoothing = new Vector2(3, 3);
	[SerializeField] private Vector2 targetDirection;
	[SerializeField] private Vector2 targetCharacterDirection;

	void Start() {
		// Set target direction to the camera's initial orientation.
		targetDirection = transform.localRotation.eulerAngles;
	}

	void Update() {
		// Ensure the cursor is always locked when set
		//Cursor.lockState = CursorLockMode.Locked;//.lockCursor = lockCursor;

		// Allow the script to clamp based on a desired target value.
		Quaternion targetOrientation = Quaternion.Euler(targetDirection);

		// Get raw mouse input for a cleaner reading on more sensitive mice.
		Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

		// Scale input against the sensitivity setting and multiply that against the smoothing value.
		mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity.x * smoothing.x, sensitivity.y * smoothing.y));

		// Interpolate mouse movement over time to apply smoothing delta.
		_smoothMouse.x = Mathf.Lerp(_smoothMouse.x, mouseDelta.x, 1f / smoothing.x);
		_smoothMouse.y = Mathf.Lerp(_smoothMouse.y, mouseDelta.y, 1f / smoothing.y);

		// Find the absolute mouse movement value from point zero.
		_mouseAbsolute += _smoothMouse;

		// Clamp and apply the local x value first, so as not to be affected by world transforms.
		if (clampInDegrees.x < 360) {
			_mouseAbsolute.x = Mathf.Clamp (_mouseAbsolute.x, -clampInDegrees.x * 0.5f, clampInDegrees.x * 0.5f);
		}

		Quaternion xRotation = Quaternion.AngleAxis(-_mouseAbsolute.y, targetOrientation * Vector3.right);
		transform.localRotation = xRotation;

		// Then clamp and apply the global y value.
		if (clampInDegrees.y < 360) {
			_mouseAbsolute.y = Mathf.Clamp (_mouseAbsolute.y, -clampInDegrees.y * 0.5f, clampInDegrees.y * 0.5f);
		}

		transform.localRotation *= targetOrientation;

		Quaternion yRotation = Quaternion.AngleAxis(_mouseAbsolute.x, transform.InverseTransformDirection(Vector3.up));
		transform.localRotation *= yRotation;
	}



	/*
	public float sensitivityX = 5.0f;
	public float sensitivityY = 5.0f;

	public bool invertX = false;
	public bool invertY = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.touches.Length > 0)
		{
			if (Input.touches[0].phase == TouchPhase.Moved)
			{
				Vector2 delta = Input.touches[0].deltaPosition;
				float rotationZ = delta.x * sensitivityX * Time.deltaTime;
				rotationZ = invertX ? rotationZ : rotationZ * -1;
				float rotationX = delta.y * sensitivityY * Time.deltaTime;
				rotationX = invertY ? rotationX : rotationX * -1;

				transform.localEulerAngles += new Vector3(rotationX, rotationZ, 0);
			}
		}
	}
	*/
}
