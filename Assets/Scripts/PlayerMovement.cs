using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5.0f;

	Animator ani;

	//animation states
	const float STATE_DOWN = 0.1f;
	const float STATE_UP = 1.1f;
	const float STATE_LEFT = 2.1f;
	const float STATE_RIGHT = 3.1f;

	const string DOWN = "0.1";
	const string UP = "1.1";
	const string LEFT = "2.1";
	const string RIGHT = "3.1";

	const int IDLE = 0;
	const int MOVE = 1;

	int MOVING = 0;
	float currentState = STATE_DOWN;
	float currentIdle = STATE_DOWN;


	// Use this for initialization
	void Start () {
		ani = this.GetComponent<Animator> ();
	}

	void FixedUpdate()	{
		if (Input.GetMouseButtonDown(0)) {
			ani.SetTrigger ("Attack");
		}
		var stop = new Vector3 (0, 0, 0);
		var move = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		transform.position += move * speed * Time.deltaTime;
		if (move == stop) {
			changeMove (IDLE);
		}
		if (move.x > 0) {
			changeState (STATE_RIGHT);
			changeMove (MOVE);
		} else if (move.x < 0) {
			changeState (STATE_LEFT);
			changeMove (MOVE);
		} else if (move.y < 0) {
			changeState (STATE_DOWN);
			changeMove (MOVE);
		} else if (move.y > 0) {
			changeState (STATE_UP);
			changeMove (MOVE);
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
		currentIdle = state;
	}

	void changeMove(int move) {
		ani.SetInteger ("idleMove", move);
	}

}
