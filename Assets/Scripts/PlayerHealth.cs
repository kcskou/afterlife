using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    private int Health;
    public int MaxHealth = 10;

	// Use this for initialization
	void Start () {
        Health = MaxHealth;
	}

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ghost") {
            Health--;
            print("????" + Health + "\n");
        }
    }

	// Update is called once per frame
	void Update () {
        if (Health < 0) {
            Destroy(gameObject);
        }
	}
}
