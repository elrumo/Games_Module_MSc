using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class GameController : MonoBehaviour
{

    RaceState raceState;

    public Text done;
    public CarAIControl AICar;
    public Text resultText;
    public Text timeText;
    public float startTime = 3;
    
    enum RaceState
    {
        START,
        RACING,
        FINISHED
    };

    void Start()
    {
        StartCoroutine(startCountdown());
        raceState = RaceState.START;
    }
    IEnumerator startCountdown()
    {
        int count = 3;
        while (count > 0)
        {
            resultText.text = "" + count; count--;
            yield return new WaitForSeconds(1);
        }
        raceState = RaceState.RACING;
        startTime = Time.time;
        resultText.text = "GO";
        yield return new WaitForSeconds(1);
        resultText.text = " ";
        // resultText.enabled = false; 
    }

    private void OnTriggerEnter(Collider other) {
        // Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "AICar"){
            resultText.text = "You loose"; 
        }
        if(other.gameObject.tag == "Player"){
            resultText.text = "You win";
        }
    }
    
    void Update()
    {
        if(raceState == RaceState.RACING)
        {
            timeText.text = "" + (Time.time - startTime);
        }

        if (Input.GetButtonDown("Fire1")){
            // GameObject[] AICars = GameObject.FindGameObjectsWithTag("AICar");
            // foreach(GameObject car in AICars)
            // {
            AICar.GetComponent<CarAIControl>().enabled = true;
            // }
        }

    }
}
