using UnityEngine;

public class AccelPlayerMotor : PlayerMotor {

	private Transform transform;

	private Quaternion gyroInitialRotation = Quaternion.identity;
	private Quaternion initialRotation = Quaternion.identity;

	void PlayerMotor.Init (Transform playerTransform) {
		transform = playerTransform;

		initialRotation = transform.rotation; 
		gyroInitialRotation = Input.gyro.attitude;
	}

	void PlayerMotor.Update () {
		Quaternion offsetRotation = Quaternion.Inverse(gyroInitialRotation) * Input.gyro.attitude;
		transform.rotation = initialRotation * offsetRotation;
	}

}
