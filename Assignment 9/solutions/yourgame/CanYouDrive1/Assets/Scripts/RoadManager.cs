using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] roadPrefabs;
    public float zspawn = 0;
    public float roadLength = 30 ;
    public int numOfRoads = 4; 


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numOfRoads; i++)
        {
            SpawnRoad(Random.Range(0, roadPrefabs.Length)); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRoad(int RoadIndex)
    {

        Debug.Log("KABOM!!!!"); 
        Instantiate(roadPrefabs[RoadIndex], transform.forward * zspawn, transform.rotation);
        zspawn = roadLength;
    
    }
}
