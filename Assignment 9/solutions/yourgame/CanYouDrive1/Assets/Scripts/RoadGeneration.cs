using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGeneration : MonoBehaviour
{
    [SerializeField]
    GameObject[] gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, gameObjects.Length);
        Instantiate(gameObjects[rand], transform.position , Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
