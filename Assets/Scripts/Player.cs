using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

#if	UNITY_IPHONE
	private PlayerMotor playerMotor = new GyroPlayerMotor();
#else
	private PlayerMotor playerMotor = new MousePlayerMotor();
#endif

	void Start () {
		playerMotor.Init (transform);
	}

	void Update () {
		playerMotor.Update ();
	}
}
