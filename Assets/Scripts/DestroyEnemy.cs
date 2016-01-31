using UnityEngine;
using System.Collections;

public class DestroyEnemy : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Ghost")
		{
			Destroy(other.gameObject);
		}   
	}
}
