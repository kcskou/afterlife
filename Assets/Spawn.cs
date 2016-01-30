using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject prefabGhost0;
	public GameObject prefabGhost1;
	public GameObject prefabGhost2;

	private Vector3 spawnPoint = new Vector3 (0, 0, 0);
	public int max = 40;
	public GameObject[] amount;

	public float a = 0.8f;
	public float c = 0.1f;

	void setPoints()
	{
		spawnPoint.x = Random.Range(-14.0f, 14.0f);
		spawnPoint.y = 0.5f;
		spawnPoint.z = Random.Range(-14.0f, 14.0f);
	}

	void spawnCube()
	{
		float b = Random.value;
		if (c > b)
		{
			Instantiate(prefabGhost0, spawnPoint, Quaternion.identity);
		} else
			if (a > b)
			{
				Instantiate(prefabGhost1, spawnPoint, Quaternion.identity);
			}
			else Instantiate(prefabGhost2, spawnPoint, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		amount = GameObject.FindGameObjectsWithTag("ghost");
		if (amount.Length < max)
		{
			setPoints();
			spawnCube();
		}
	}
}
