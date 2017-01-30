using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MotorType {
	MOUSE,
	GYRO,
	TOUCH
}

public interface PlayerMotor {
	void Init (Transform playerTransform);
	void Update ();
}