using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerAttack : MonoBehaviour {

    public static int maxPenalty = 2;
    public static int maxAttack = 1;
    private float penaltyTimer;
    private float attackTimer;
    private bool isPenalized;
    private bool hasAttacked;
    public GameObject prefabAttack;
    private GameObject clone;
    public float dis = 1f;

	// Use this for initialization
	void Start () {
        prefabAttack = GameObject.Find("Attack");
        penaltyTimer = 0;
        attackTimer = 0;
        isPenalized = false;
        hasAttacked = false;
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        bool isAttacking = Input.GetButtonDown("Boost");


        if (isAttacking && !hasAttacked && penaltyTimer == 0) {
            Attack();
        }
        if (penaltyTimer > 0 && isPenalized) {
            penaltyTimer -= Time.deltaTime;
        }
        else if (penaltyTimer <= 0 && isPenalized) {
            isPenalized = false;
        }

        if (attackTimer > 0 && hasAttacked) {
            attackTimer -= Time.deltaTime;
            print(attackTimer + "\n");
        }
        else if (attackTimer <= 0 && hasAttacked) {
            print("YAAAAPIIII\n");
            Destroy(clone);
            hasAttacked = false;
        }
	}

    void Attack() {
        float x = transform.position.x;
        float y = transform.position.y;
        Vector2 spawnPosition = new Vector2(0, 0);

        Vector3 moveVecJoystick = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"),
            CrossPlatformInputManager.GetAxis("Vertical"), 0);
        Vector3 moveVecKeyboard = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

		if (moveVecJoystick.x > moveVecJoystick.y) {
			if (moveVecKeyboard.x > 0 || moveVecJoystick.x > 0) {
				// Right
                spawnPosition = new Vector2(x + dis, y);
			} else if (moveVecKeyboard.y < 0 || moveVecJoystick.y < 0) {
				// Down
                spawnPosition = new Vector2(x, y + dis);

			}
		} else if (moveVecKeyboard.x < 0|| moveVecJoystick.x < 0) {
			// Left
            spawnPosition = new Vector2(x - dis, y);
        }
        else if (moveVecKeyboard.y > 0 || moveVecJoystick.y > 0) {
            // Up
            spawnPosition = new Vector2(x, y + dis);
        }
        else {
            print("!!!!!!!!!!!!!!!!!!!!!\n");
            spawnPosition = new Vector2(x, y);
        }

        clone = Instantiate(prefabAttack, spawnPosition, Quaternion.identity) as GameObject;
        isPenalized = true;
        hasAttacked = true;
        attackTimer = 2;
    }
}
