using UnityEngine;

public class GyroPlayerMotor : PlayerMotor {

	private Transform transform;

	private Quaternion gyroInitialRotation = Quaternion.identity;
	private Quaternion initialRotation = Quaternion.identity;

	private bool invert = true;

	void PlayerMotor.Init (Transform playerTransform) {
		transform = playerTransform;

		Input.gyro.enabled = true;

		initialRotation = transform.rotation; 
		gyroInitialRotation = Input.gyro.attitude;
	}

	void PlayerMotor.Update () {
		Quaternion offsetRotation = Quaternion.Inverse(gyroInitialRotation) * Input.gyro.attitude;

		transform.rotation = initialRotation * offsetRotation;
	}

}
