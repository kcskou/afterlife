using UnityEngine;
using System.Collections;

public class Player2Movement : MonoBehaviour {

	public float speed = 5.0f;

	void FixedUpdate()	{
		var move = new Vector3 (Input.GetAxis ("Horizontal2"), Input.GetAxis ("Vertical2"), 0);
		transform.position += move * speed * Time.deltaTime;
	}

}
