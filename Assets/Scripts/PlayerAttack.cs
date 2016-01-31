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
    private GameObject prefabAttack, clone;

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

        Vector2 dirVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"),
            CrossPlatformInputManager.GetAxis("Vertical"));

        //bool isAttacking = CrossPlatformInputManager.GetButton("Attack");

        bool isAttacking = Input.GetButtonDown("Fire1");


        if (isAttacking && penaltyTimer == 0) {
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
    
        Vector2 position = new Vector2(x,y);
        clone = Instantiate(prefabAttack, position, Quaternion.identity) as GameObject;
        isPenalized = true;
        hasAttacked = true;
        attackTimer = 4;
    }
}
