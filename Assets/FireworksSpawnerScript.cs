using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksSpawnerScript : MonoBehaviour {

    [SerializeField]
    public int spawnMultiplier;
    [SerializeField]
    public int degreeVariance;
    [SerializeField]
    public GameObject FireworkPrefab;

    float currentTime;
    float randomTime;

	// Use this for initialization
	void Start () {
        currentTime = 0;
        setNewRandomTime();
    }

    // Spawns a firework
    void spawn()
    {
        float rotation = Random.Range(-1 * degreeVariance, 1 * degreeVariance); //TODO

        float x = Random.Range(-degreeVariance, degreeVariance) + transform.position.x;
        float y = Random.Range(-degreeVariance, degreeVariance) + transform.position.y;
        float z = Random.Range(-degreeVariance, degreeVariance) + transform.position.z;

        Instantiate(FireworkPrefab, new Vector3(x, y, z), transform.rotation);
    }

    void setNewRandomTime()
    {
        randomTime = Random.Range(0, 100) / spawnMultiplier;
    }

    // Update is called once per frame
    void Update () {
        if(currentTime > randomTime)
        {
            spawn();
            currentTime = 0;
            setNewRandomTime();
        }

        currentTime = currentTime + Time.deltaTime;
	}
}