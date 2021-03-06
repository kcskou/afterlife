﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlobControl : MonoBehaviour {

	Animator ani;
	public static List<BlobControl> ghostList = new List<BlobControl>();

	//public float speed = 5.0f;
	public GameObject player;
	public int moveSpeed = 4;
	private int MaxDist = 10000000;
	private int MinDist = 1000000;
	private Rigidbody rb;
	private int rotateSpeed = 1;

	//animation states
	const float STATE_DOWN = 0.1f;
	const float STATE_UP = 1.1f;
	const float STATE_LEFT = 2.1f;
	const float STATE_RIGHT = 3.1f;

	const string DOWN = "0.1";
	const string UP = "1.1";
	const string LEFT = "2.1";
	const string RIGHT = "3.1";


	float currentState = STATE_DOWN;

	// void FixedUpdate()	{
	//	var move = new Vector3 (Input.GetAxis ("Horizontal2"), Input.GetAxis ("Vertical2"), 0);
	//	transform.position += move * speed * Time.deltaTime;
	//}

	void OnEnable()
	{
		if (!ghostList.Contains(this)) ghostList.Add(this);
	}

	void OnDisable()
	{
		if (ghostList.Contains(this)) ghostList.Remove(this);
	}

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		rb = GetComponent<Rigidbody>();
		ani = this.GetComponent<Animator> ();



	}
	// Update is called once per frame
	void Update()
	{
		Vector3 direction = player.transform.position - transform.position ;

		// Normalize it so that it's a unit direction vector
		direction.Normalize();

		// Move ourselves in that direction
		transform.position += direction * moveSpeed * Time.deltaTime;
		if (direction.x < 0) {
			changeState (STATE_DOWN);
		} else
			changeState (STATE_UP);

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

	void changeMove(int move) {
		ani.SetInteger ("idleMove", move);
	}

}
