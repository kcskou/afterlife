using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestroyEnemy : MonoBehaviour {
    private int count;
    public Text countText;

    void Start(){
        countText.text = "0";
        count = 0;
        setCountText();
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
			Destroy(other.gameObject);
            count = count + 100;
		}   
	}
}
