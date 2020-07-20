using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision){
        // Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(0);
    }
}
