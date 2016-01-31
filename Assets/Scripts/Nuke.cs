using UnityEngine;
using System.Collections;

public class Nuke : MonoBehaviour {

	void DestroyGhosts() {
		GameObject[] blownUps = GameObject.FindGameObjectsWithTag ("Ghost");
		foreach (GameObject ghosts in blownUps) {
			GameObject.Destroy (ghosts);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			DestroyGhosts ();
		}
		Destroy (this.gameObject);
	}

}
