using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpDown : MonoBehaviour
{
    public AnimationCurve curve;
  
    private void OnCollisionEnter2D(Collision2D collision){
        // Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(0);
    }
    
    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(transform.position.x,
            curve.Evaluate((Time.time % curve.length)),
            transform.position.z);
    }
}
