using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5.0f;

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

	void FixedUpdate()	{
		var move = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		transform.position += move * speed * Time.deltaTime;
		if (move.x > 0) {
			changeState (STATE_RIGHT);
		} else if (move.x < 0) {
			changeState (STATE_LEFT);
		} else if (move.y < 0) {
			changeState (STATE_DOWN);
		} else if (move.y > 0) {
			changeState (STATE_UP);
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
