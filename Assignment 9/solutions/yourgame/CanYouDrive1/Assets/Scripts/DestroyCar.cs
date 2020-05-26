using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCar : MonoBehaviour
{
   
    public int minY = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < minY)
            Destroy(gameObject);
       
    }
  
}
