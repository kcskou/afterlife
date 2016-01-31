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
		if (Input.GetKeyDown (KeyCode.W)) {
			changeState (STATE_UP);
		} else if (Input.GetKeyDown (KeyCode.S)) {
			changeState (STATE_DOWN);
		} else if (Input.GetKeyDown (KeyCode.A)) {
			changeState (STATE_LEFT);
		} else if (Input.GetKeyDown (KeyCode.D)) {
			changeState (STATE_RIGHT);
		}

	}

	void changeState(int state) {
		if (currentState == state) {
			return;
		}

		switch (state) {

		case STATE_DOWN:
			ani.SetInteger ("State", STATE_DOWN);
			break;

		case STATE_UP:
			ani.SetInteger ("State", STATE_UP);
			break;

		case STATE_LEFT:
			ani.SetInteger ("State", STATE_LEFT);
			break;

		case STATE_RIGHT:
			ani.SetInteger ("State", STATE_RIGHT);
			break;
		}

		currentState = state;
	}
}
