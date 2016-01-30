using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    public float moveForce = 5, boostMultiplier = 2;
    Rigidbody2D myBody;

	void Start () {
        myBody = this.GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"),
            CrossPlatformInputManager.GetAxis("Vertical")) * moveForce;
        bool isBoosting = CrossPlatformInputManager.GetButton("Boost");
        myBody.AddForce(moveVec * (isBoosting ? boostMultiplier : 1));

	}
}
