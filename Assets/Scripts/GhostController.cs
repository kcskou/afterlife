using UnityEngine;
using System.Collections;

public class GhostController : MonoBehaviour {

	//public float speed = 5.0f;
    public GameObject player;
    public int moveSpeed = 4;
    private int MaxDist = 10000000;
    private int MinDist = 1000000;
    private Rigidbody rb;
    private int rotateSpeed = 1;

    // void FixedUpdate()	{
    //	var move = new Vector3 (Input.GetAxis ("Horizontal2"), Input.GetAxis ("Vertical2"), 0);
    //	transform.position += move * speed * Time.deltaTime;
    //}

    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        


    }
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position ;

        // Normalize it so that it's a unit direction vector
        direction.Normalize();

        // Move ourselves in that direction
        transform.position += direction * moveSpeed * Time.deltaTime;
    }




    // rb.constraints = RigidbodyConstraints.FreezeRotation;
    //  transform.LookAt(player.transform);
    // transform.position += transform.right * MoveSpeed * Time.deltaTime;

    //rotate to look at the player
    //  transform.rotation = Quaternion.Slerp(transform.rotation,
    //  Quaternion.LookRotation(player.transform.position - transform.position), rotateSpeed * Time.deltaTime);
//}

}
