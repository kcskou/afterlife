using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestroyEnemy : MonoBehaviour {
    public int count =0;
    public Text countText;

    public Text highestCountText;
    public static DestroyEnemy instance;

    void Awake()
    {
        instance = this;
    }
    void Start(){
        countText.text = "0";
        count = 0;
        setCountText();
        if(highestCountText)
        {
            if (PlayerPrefs.GetInt("highscore", 0) == 0) highestCountText.text = "";
            else
            highestCountText.text = "Highest Score: " + PlayerPrefs.GetInt("highscore", 0);
        }
    }

    void FixedUpdate() {
        setCountText();

    }

    void setCountText(){
        countText.text = "Score: " + count.ToString();

    }

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Ghost")
		{
            SoundManager.Play("CircleTouch");
            Destroy(other.gameObject);
            count = count + 100;
            Spawn.diffLevel = Mathf.FloorToInt(count / 1000);
		}   
	}
}
