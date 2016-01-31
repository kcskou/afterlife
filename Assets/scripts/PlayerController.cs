using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 5.0f, boostMultiplier = 2.0f;
    private bool gamePaused;
    public Text pauseText;

    void Start () {
        // myBody = this.GetComponent<Rigidbody2D>();  // KKOU
        pauseText.text = "";
        gamePaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("q"))
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

    void FixedUpdate () {
        Vector3 moveVecJoystick = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"),
            CrossPlatformInputManager.GetAxis("Vertical"), 0);
        bool isBoosting = CrossPlatformInputManager.GetButton("Boost");
        transform.position += moveVecJoystick * speed * Time.deltaTime;

        Vector3 moveVecKeyboard = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += moveVecKeyboard * speed * Time.deltaTime;
    }
}
