using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerAttack : MonoBehaviour {

    private static int maxPenalty = 2;
    public int penaltyTimer;
    bool isPenalized;
    private GameObject prefabAttack;

	// Use this for initialization
	void Start () {
        penaltyTimer = 0;
        isPenalized = false;
        prefabAttack = GameObject.Find("Attack");
	}
	
	// Update is called once per frame
	void Update() {

        Vector2 dirVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"),
            CrossPlatformInputManager.GetAxis("Vertical"));

        bool isAttacking = CrossPlatformInputManager.GetButton("Attack");

        if (isAttacking && penaltyTimer == 0) {
            Attack();
        }
        if (penaltyTimer > 0 && isPenalized) {
            penaltyTimer -= Timer.deltaTime;
        }
        else if (penaltyTimer <= 0 && isPenalized) {
            Destroy(prefabAttack);
            isPenalized = false;
        }
	}

    void Attack() {
        float x = transform.position.x;
        float y = transform.position.y;
    
        Vector2 position = new Vector2(x,y);
        Instantiate(prefabAttack, position, Quaternion.identity);
        isPenalized = true;
    }
}
