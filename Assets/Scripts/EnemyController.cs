using UnityEngine;
using System.Collections;

public class GhostController : MonoBehaviour {

    private GameObject player, attack;
    public int moveSpeed = 4;
    private int MaxDist = 1000000;
    private int MinDist = 1000000;
    private Rigidbody rb;
    private int rotateSpeed = 1;
    private float moveForce = 5;

    void Start()
    {
        player = GameObject.Find("Player");
        attack = GameObject.Find("Attack");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction;

        if (player != null)
        {
            direction = player.transform.position - transform.position;
        }
        else {
            direction = transform.position;
        }

        // Normalize it so that it's a unit direction vector
        direction.Normalize();

        // Move ourselves in that direction
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Attack") {
            Vector2 dirVec = new Vector2(attack.position - transform.position);
            Vector2 moveVec = dirVec * moveForce;
            AddForce(moveVec);
        }
    }
}
