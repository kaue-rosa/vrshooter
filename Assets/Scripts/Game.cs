using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			EnterSRange ();
		}
	}

	public void EnterSRange() {
		SceneManager.LoadScene ("srange");
	}
}
