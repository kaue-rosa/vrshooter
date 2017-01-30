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

		if (invert) {
			Vector3 inverted = new Vector3 (
				offsetRotation.eulerAngles.x * -1,
				offsetRotation.eulerAngles.y * -1,
				offsetRotation.eulerAngles.z
			);
			offsetRotation = Quaternion.Euler (inverted);
		}

		transform.rotation = initialRotation * offsetRotation;
	}

}
