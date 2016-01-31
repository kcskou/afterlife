using UnityEngine;
using System.Collections;


public class Spawn : MonoBehaviour {

	public GameObject[] prefabGhosts;
	public Transform minSpawn;
	public Transform maxSpawn;

	public Transform playAreaMin;
	public Transform playAreaMax;

	private Vector3 spawnPoint;
	public float deltaSpawnBreaks = -0.02f;

	public float spawnHeight = 0.0f;
	public float maxNumGhost = 40;
	private int amount;

	private float nextSpawnTime = 0.0f;
    public float spawnBreaks = 2.0f;
    public float spawnWait = 1.0f;

    static public int diffLevel = 0;
    

	void Start(){
        Debug.Log("StartingSpawn");
        diffLevel = 0;
        spawnBreaks = 2.0f;
        StartCoroutine(ChangeSpawnTime());
        StartCoroutine(SpawnLogic());
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
            int ghostIndex = Mathf.Clamp(diffLevel, 0, prefabGhosts.Length);
			Instantiate (prefabGhosts [Random.Range (0, ghostIndex)], GetSpawnPoint (), Quaternion.identity);
		}
	}
	
    IEnumerator SpawnLogic()
    {
        while(true)
        {
            spawnCube();
            yield return new WaitForSeconds(spawnBreaks);
        }
    }

    IEnumerator ChangeSpawnTime()
    {
        while(true)
        {
            spawnBreaks = Mathf.Clamp(spawnBreaks + deltaSpawnBreaks, 0.5f, 2);
            yield return new WaitForSeconds(spawnWait);
        }
    }
	//// Update is called once per frame
	//void Update () {

	//	if (Time.time > nextSpawnTime) {
	//		//max += spawnRate * Time.deltaTime;
	//		spawnCube();
	//		nextSpawnTime += spawnBreaks;

	//		float check = spawnBreaks + deltaSpawnBreaks;
	//		if (check > 0.5) {
	//			spawnBreaks += deltaSpawnBreaks;
	//		}
	//	}
	//}
}
