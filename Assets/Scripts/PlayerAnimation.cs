using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	private bool isStanding = true; // player is idle

	Animator ani;

	// flags to be checked
	bool isUp = false;
	bool isDown = true;
	bool isLeft = false;
	bool isRight = false;

	//animation states
	const int STATE_DOWN = 0;
	const int STATE_UP = 1;
	const int STATE_LEFT = 2;
	const int STATE_RIGHT = 3;

	int currentState = STATE_DOWN;

	// Use this for initialization
	void Start () {
		ani = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// check for input
		if(Input.GetKeyDown (KeyCode.W)) {

		}
	}

	void changeState(int state) {
		if (currentState == state) {
			return;
		}

		switch (state) {

		case STATE_DOWN:
			ani.SetInteger ("state", STATE_DOWN);
			break;

		case STATE_UP:
			ani.SetInteger ("state", STATE_UP);
			break;

		case STATE_LEFT:
			ani.SetInteger ("state", STATE_LEFT);
			break;

		case STATE_RIGHT:
			ani.SetInteger ("state", STATE_RIGHT);
			break;
		}

		currentState = state;
	}
}
