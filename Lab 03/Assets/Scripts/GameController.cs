using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    int totalScore = 0;
    public float timeLeft = 10.0f;

    public Text timeText;
    public Text goalText;
    public Text winningText;

    int numTargets;
    // Update is called once per frame

    // Start is called before the first frame update
    void Start()
    {
        numTargets = GameObject.FindObjectsOfType<Destroyable>().Length;
    }

    void Update()
    {
        // if (timeLeft > 0)
        // {
        //     Debug.Log("game lost");
        // }

        if (timeLeft > 0){
            timeLeft -= Time.deltaTime;
        }

        // format to a string with not decimal places
        timeText.text = timeLeft.ToString("0" + " seconds");

        goalText.text = timeLeft.ToString(GameObject.FindObjectsOfType<Destroyable>().Length + "/" + numTargets);

        if(GameObject.FindObjectsOfType<Destroyable>().Length == 0){
            winningText.text = timeLeft.ToString("Awesome, you did it!");
        } else{
            winningText.text = timeLeft.ToString(" ");
        }

        if(timeLeft < 0){
            winningText.text = timeLeft.ToString("You lost");
        }
    }

    public void TargetDestroyed()
    {
        Debug.Log("Current score: " + totalScore);
        Debug.Log("Number of targets: " + GameObject.FindObjectsOfType<Destroyable>().Length);
        
        timeLeft += 4;

        if (GameObject.FindObjectsOfType<Destroyable>().Length == 0)
        {
            Debug.Log("game won");
        }    
    }
}
