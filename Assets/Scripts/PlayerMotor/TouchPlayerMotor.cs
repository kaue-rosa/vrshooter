using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPlayerMotor : PlayerMotor {

	private Transform transform;

	private float sensitivityX = 30.0f;
	private float sensitivityY = 30.0f;

	private bool invertX = false;
	private bool invertY = true;

	void PlayerMotor.Init (Transform playerTransform) {
		transform = playerTransform;
	}

	void PlayerMotor.Update () {
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
}
