﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private PlayerMotor playerMotor = new MousePlayerMotor();

	void Start () {
		playerMotor.Init (transform);
	}

	void Update () {
		playerMotor.Update ();
	}
}