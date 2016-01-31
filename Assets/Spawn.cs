using UnityEngine;
using System.Collections;


public class Spawn : MonoBehaviour {

	public GameObject[] prefabGhosts;
	public Transform minSpawn;
	public Transform maxSpawn;

	public Transform playAreaMin;
	public Transform playAreaMax;

	private Vector3 spawnPoint;
	//private Vector3 limitMin;
	//private Vector3 limitMax;
	//private Vector3 outerSpawnMin;
	//private Vector3 outerSpawnMax;

	public float spawnHeight = 0.5f;
	public int max = 40;
	public GameObject[] amount;

	public float a = 0.8f;
	public float c = 0.1f;

	void Start(){

		//spawnPoint = Camera.main.ViewportPointToRay]
		//limitMin = Camera.main.ScreenToWorldPoint (new Vector3 (0, 0, Camera.main.transform.position.y));
		//limitMax = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, Camera.main.transform.position.y));
		//outerSpawnMin = new Vector3 (limitMin.x + 1, limitMin.z + 1);
		//outerSpawnMax = new Vector3 (limitMax.x + 1, limitMax.z + 1);
	}

	void setPoints()
	{	
		spawnPoint.x = Random.Range(0.0f,1.0f);
		spawnPoint.y = 0.5f;
		spawnPoint.z = Random.Range(0.0f,1.0f);
	}


	Vector3 GetSpawnPoint() {
		float x = 0;
		if (Random.value < 0.5) {
			x = Random.Range (minSpawn.position.x, playAreaMin.position.x);
		} else {
			x = Random.Range (playAreaMax.position.x, maxSpawn.position.x);
		}
		float z = 0;
		if (Random.value < 0.5) {
			z = Random.Range (minSpawn.position.z, playAreaMin.position.z);
		} else {
			z = Random.Range (playAreaMax.position.z, maxSpawn.position.z);
		}

		return new Vector3 (x, spawnHeight, z);
	}

	void spawnCube()
	{
		float b = Random.value;
		
		Instantiate(prefabGhosts[Random.Range(0,prefabGhosts.Length)], GetSpawnPoint(), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		amount = GameObject.FindGameObjectsWithTag("ghost");
		//amount = GhostController.ghostList.Count;
		if (amount.Length < max)
		{
			setPoints();
			spawnCube();
		}
	}
}
