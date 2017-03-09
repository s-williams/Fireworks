using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkScript : MonoBehaviour {

    [SerializeField]
    public float speedMultiplier;
    [SerializeField]
    public float timeMultiplier;
    [SerializeField]
    public float sparkleSpread;
    [SerializeField]
    public GameObject FireworkSparklePrefab;
    
    float currentTime;
    float randomTime;
    float speed;
    float xDegree;
    float zDegree;


    // Use this for initialization
    void Start () {
        currentTime = 0;
        setNewRandomTime();
        speed = Random.Range(1, 5) * speedMultiplier;
        xDegree = Random.Range(-1, 1);
        zDegree = Random.Range(-1, 1);

        gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    void setNewRandomTime()
    {
        randomTime = Random.Range(5, 100) / timeMultiplier;
    }

    // Explode
    void Kaboom ()
    {
        for(int i = 0; i < Random.Range(10,30); i++)
        {
            float x = Random.Range(-sparkleSpread, sparkleSpread) + transform.position.x;
            float y = Random.Range(-sparkleSpread, sparkleSpread) + transform.position.y;
            float z = Random.Range(-sparkleSpread, sparkleSpread) + transform.position.z;
            Instantiate(FireworkSparklePrefab, new Vector3(x,y, z), transform.rotation);
        }
        Destroy(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        if (currentTime > randomTime)
        {
            Kaboom();
            currentTime = 0;
            setNewRandomTime();
        }

        currentTime = currentTime + Time.deltaTime;
        transform.Translate(0 * Time.deltaTime, speed * Time.deltaTime, zDegree * Time.deltaTime);
	}
}
