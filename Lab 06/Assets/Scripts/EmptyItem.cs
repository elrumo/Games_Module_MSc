using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmptyItem : MonoBehaviour
{

    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void emptyItem(){
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
