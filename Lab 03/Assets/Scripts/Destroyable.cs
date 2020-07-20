using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        
    }

    public int timeBonus = 10;

    private void OnCollisionEnter(Collision collision)
    {
        // destroy this object
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        // tell the game controller
        if (gameController != null)
        {
            gameController.TargetDestroyed();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
