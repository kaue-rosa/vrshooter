using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour {

	private static GameSettings instance;

	private MotorType activeMotor = MotorType.MOUSE;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	public static GameSettings GetInstance() {
		return instance;
	}

	public MotorType GetActiveMotorType() {
		return instance.activeMotor;
	}

	public void SetMotorType(int motorType) {
		instance.activeMotor = (MotorType) motorType;
	}
}
