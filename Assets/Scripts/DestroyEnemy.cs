using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestroyEnemy : MonoBehaviour {
    public Text countText;
    private int count;

    void Start(){
        countText.text = "0";
        count = 0;
        setCountText();
    }

    void FixedUpdate() {
        setCountText();

    }

    void setCountText(){
        countText.text = "Count: " + count.ToString();

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
