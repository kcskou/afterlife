using UnityEngine;
using System.Collections;

public class ObstacleGenerator : MonoBehaviour {

    public GameObject spawnObstacle;
    private static int amount = 5;

    private GameObject prefabObstacle0;
    private GameObject prefabObstacle1;
    private GameObject prefabObstacle2;
    private GameObject dummy;

    void SpawnCube(){
        for (int i = 0; i < amount; i++)
        {
            Vector3 position = new Vector3(Random.Range(-10.0F, 10.0F), Random.Range(-10.0F, 10.0F));
            int randNum = Random.Range(0,2);
            switch (randNum)
            {
                // Add more cases for different obstacles
                case 0: spawnObstacle = prefabObstacle0; break;
                case 1: spawnObstacle = prefabObstacle1; break;
                case 2: spawnObstacle = prefabObstacle2; break;
                default: spawnObstacle = dummy; break;
            }
            Instantiate(spawnObstacle, position, Quaternion.identity);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            SpawnCube();
        }
    }

	// Use this for initialization
	void Start () {
        // Attach your own objects to variables
        prefabObstacle0 = GameObject.Find("Enemy");
        prefabObstacle1 = GameObject.Find("Enemy");
        prefabObstacle2 = GameObject.Find("Enemy");
        // Create dummy object to handle default case
        dummy = GameObject.Find("Enemy");

        SpawnCube();
	}
}
