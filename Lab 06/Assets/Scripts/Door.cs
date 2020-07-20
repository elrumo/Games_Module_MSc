using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public void Open(){
        transform.rotation = Quaternion.Euler(0,90,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
