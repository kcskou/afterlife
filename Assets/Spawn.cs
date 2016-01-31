using UnityEngine;
using System.Collections;


public class Spawn : MonoBehaviour {

	public GameObject[] prefabGhosts;
	public Transform minSpawn;
	public Transform maxSpawn;

	public Transform playAreaMin;
	public Transform playAreaMax;

	private Vector3 spawnPoint;
	public float deltaSpawnBreaks = -0.05f;

	public float spawnHeight = 0.0f;
	public float maxNumGhost = 40;
	private int amount;

	private float nextSpawnTime = 0.0f;
	public float spawnBreaks = 1.5f;

	void Start(){
		
		//spawnPoint = Camera.main.ViewportPointToRay]
		//limitMin = Camera.main.ScreenToWorldPoint (new Vector3 (0, 0, Camera.main.transform.position.y));
		//limitMax = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, Camera.main.transform.position.y));
		//outerSpawnMin = new Vector3 (limitMin.x + 1, limitMin.z + 1);
		//outerSpawnMax = new Vector3 (limitMax.x + 1, limitMax.z + 1);
	}
		
	Vector3 GetSpawnPoint() {
		float x = 0;
		float y = 0;
		if (Random.value < 0.35) {
			x = Random.Range (minSpawn.position.x, playAreaMin.position.x);
			y = Random.Range (playAreaMin.position.y, playAreaMax.position.y);
		} else if (Random.value < 0.5) {
			x = Random.Range (playAreaMax.position.x, maxSpawn.position.x);
			y = Random.Range (playAreaMin.position.y, playAreaMax.position.y);
		} else if (Random.value < 0.75) {
			x = Random.Range (playAreaMin.position.x, playAreaMax.position.x);
			y = Random.Range (minSpawn.position.y, playAreaMin.position.y); 
		} else {
			x = Random.Range (playAreaMin.position.x, playAreaMax.position.x);
			y = Random.Range (playAreaMax.position.y, maxSpawn.position.y); 
		}
		return new Vector3 (x, y, spawnHeight);
	}

	void spawnCube()
	{	
		amount = GhostController.ghostList.Count;
		if (amount < maxNumGhost) {		
			
			Instantiate (prefabGhosts [Random.Range (0, prefabGhosts.Length)], GetSpawnPoint (), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > nextSpawnTime) {
			//max += spawnRate * Time.deltaTime;
			spawnCube();
			nextSpawnTime += spawnBreaks;

			float check = spawnBreaks + deltaSpawnBreaks;
			if (check > 0.5) {
				spawnBreaks += deltaSpawnBreaks;
			}
		}
	}
}
