using UnityEngine;
using System.Collections;


public class Spawn : MonoBehaviour
{

    public GameObject prefabGhost0;
    public GameObject prefabGhost1;
    public GameObject prefabGhost2;

    private Vector3 spawnPoint;
    private Vector3 limitMin;
    private Vector3 limitMax;
    private Vector3 outerSpawnMin;
    private Vector3 outerSpawnMax;

    public int max = 40;
    public GameObject[] amount;

    public float a = 0.8f;
    public float c = 0.1f;

    void Start()
    {

        spawnPoint = Camera.main.WorldToViewportPoint(transform.position);
        limitMin = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.y));
        limitMax = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.y));
        outerSpawnMin = new Vector3(limitMin.x + 1, 0, limitMin.z + 1);
        outerSpawnMax = new Vector3(limitMax.x + 1, 0, limitMax.z + 1);
    }

    void setPoints()
    {

        spawnPoint.x = Random.Range(0, 1);
        spawnPoint.y = 0.5f;
        spawnPoint.z = Random.Range(0, 1);
    }


    void spawnCube()
    {
        float b = Random.value;
        if (a > b)
        {
            spawnPoint.x = spawnPoint.x > 0.5 ? outerSpawnMax.x : outerSpawnMin.x;
            Instantiate(prefabGhost0, spawnPoint, Quaternion.identity);
        }
        else
            if (a > b)
            {
                spawnPoint.z = spawnPoint.y > 0.5 ? outerSpawnMax.y : outerSpawnMin.y;
                Instantiate(prefabGhost1, spawnPoint, Quaternion.identity);
            }
            else Instantiate(prefabGhost2, spawnPoint, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        amount = GameObject.FindGameObjectsWithTag("ghost");
        if (amount.Length < max)
        {
            setPoints();
            spawnCube();
        }
    }
}