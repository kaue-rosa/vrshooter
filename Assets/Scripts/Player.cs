using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private PlayerMotor playerMotor;
	private Dictionary<MotorType, PlayerMotor> motors = new Dictionary<MotorType, PlayerMotor> {
		{MotorType.MOUSE , new MousePlayerMotor()},
		{MotorType.TOUCH, new TouchPlayerMotor()},
		{MotorType.GYRO, new GyroPlayerMotor()}
	};

	void Start () {
		motors.TryGetValue(GameSettings.GetInstance ().GetActiveMotorType (), out playerMotor);
		playerMotor.Init (transform);
	}

	void Update () {
		playerMotor.Update ();

		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		if(Physics.Raycast(transform.position,fwd,out hit)) {
			if (hit.collider.tag == "Target") {
				Destroy (hit.collider.gameObject);
			}
		}
	}
}
