using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    private int Health;
    private static int MaxHealth = 10;

	// Use this for initialization
	void Start () {
        Health = MaxHealth;
	}

    void OnTriggerEnter(Collision other) {
        if (other.gameObject.name == "Ghost") {
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
