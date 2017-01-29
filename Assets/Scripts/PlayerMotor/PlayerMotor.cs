using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerMotor {
	void Init (Transform playerTransform);
	void Update ();
}