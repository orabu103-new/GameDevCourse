using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField]
    public GameObject roadPrefabs;
    public float zspawn = 235;
    public float roadLength = 150 ;
    private List<GameObject> activtyRoad = new List<GameObject>();

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 startRoad = new Vector3(0,0,90) ;
        GameObject newObject = Instantiate(roadPrefabs, startRoad, transform.rotation);
        activtyRoad.Add(newObject);

      
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.z >  roadLength)
        {
            roadLength = player.transform.position.z + zspawn;
            SpawnRoad();
            if (activtyRoad.Count > 2)
            {
                DeleteRoad();
            }
           
        }
    }

    public void SpawnRoad()
    {

        Debug.Log("KABOM!!!!"); 
      GameObject newObject =  Instantiate(roadPrefabs, transform.forward * roadLength, transform.rotation);
        activtyRoad.Add(newObject);
        
    
    }
    private void DeleteRoad()
    {
        Destroy(activtyRoad[0]);
        activtyRoad.RemoveAt(0);
    }
}
