using UnityEngine;

public class AccelPlayerMotor : PlayerMotor {

	private Transform transform;

	private float sensitivityX = 5.0f;
	private float sensitivityY = 5.0f;

	private bool invertX = false;
	private bool invertY = false;

	// Use this for initialization
	void PlayerMotor.Init (Transform playerTransform) {
		transform = playerTransform;
	}

	// Update is called once per frame
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
