using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

    public int level;
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Ghost")
		{
            Application.LoadLevel("Game Over Menu");
            print ("DEATH");
           
		}   
	}


}
