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
	const float STATE_DOWN = 0.0f;
	const float STATE_UP = 1.0f;
	const float STATE_LEFT = 2.0f;
	const float STATE_RIGHT = 3.0f;

	const string DOWN = "0.0";
	const string UP = "1.0";
	const string LEFT = "2.0";
	const string RIGHT = "3.0";


	float currentState = STATE_DOWN;

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

	void changeState(float state) {
		if (currentState == state) {
			return;
		}

		switch (state.ToString()) {

		case DOWN:
			ani.SetFloat ("Blend", STATE_DOWN);
			break;

		case UP:
			ani.SetFloat ("Blend", STATE_UP);
			break;

		case LEFT:
			ani.SetFloat ("Blend", STATE_LEFT);
			break;

		case RIGHT:
			ani.SetFloat ("Blend", STATE_RIGHT);
			break;
		}

		currentState = state;
	}
}
