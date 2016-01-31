using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5.0f;
    private bool gamePaused;
    public Text pauseText;


    void Start(){
        pauseText.text = "";
        gamePaused = false;

        ani = this.GetComponent<Animator>();


    }


    void Update()
    {
            if (Input.GetKeyDown("q") || Input.GetKeyDown(KeyCode.Escape))
            {
                if (Time.timeScale == 1)
                {
                    Time.timeScale = 0;
                    pauseText.text = "Paused";
                }
                else
                {
                    Time.timeScale = 1;
                    pauseText.text = "";
                }
            }
    }




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

    

	void FixedUpdate()	{
		if (Input.GetMouseButtonDown(0)) {
			ani.SetTrigger ("Attack");
		}
        Vector3 moveVecJoystick = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"),
    CrossPlatformInputManager.GetAxis("Vertical"), 0);
        bool isBoosting = CrossPlatformInputManager.GetButton("Boost");
        transform.position += moveVecJoystick * speed * Time.deltaTime;

        Vector3 moveVecKeyboard = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += moveVecKeyboard * speed * Time.deltaTime;
        var stop = new Vector3 (0, 0, 0);
		if (moveVecKeyboard == stop || moveVecJoystick == stop) {
			changeMove (IDLE);
		}
		if (moveVecKeyboard.x > 0 || moveVecJoystick.x > 0) {
			changeState (STATE_RIGHT);
			changeMove (MOVE);
		} else if (moveVecKeyboard.x < 0 || moveVecJoystick.x < 0) {
			changeState (STATE_LEFT);
			changeMove (MOVE);
		} else if (moveVecKeyboard.y < 0 || moveVecJoystick.y < 0) {
			changeState (STATE_DOWN);
			changeMove (MOVE);
		} else if (moveVecKeyboard.y > 0 || moveVecJoystick.y > 0) {
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
