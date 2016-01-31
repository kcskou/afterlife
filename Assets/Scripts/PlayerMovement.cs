using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5.0f;
    private bool gamePaused;
    public Text pauseText;


    void Start(){
        pauseText.text = "";
        gamePaused = false;


    }


    void Update()
    {
        {
            if (Input.GetKeyDown("q"))
            {
                if (Time.timeScale == 1)
                {
                    Time.timeScale = 0;
                    pauseText.text = "Paused";
                }
                else
                {
                    Time.timeScale = 1;
                    pauseText.text = "";
                }
            }
        }
    }




	void FixedUpdate()	{
		var move = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;
    }




}
