using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

    public int level;
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Ghost")
		{
            if (DestroyEnemy.instance)
            {
                if (PlayerPrefs.GetInt("highscore", 0) < DestroyEnemy.instance.count)
                {
                    PlayerPrefs.SetInt("highscore", DestroyEnemy.instance.count);
                    PlayerPrefs.Save();
                }
            }
            Application.LoadLevel("Game Over Menu");
            print ("DEATH");
           
		}   
	}


}
