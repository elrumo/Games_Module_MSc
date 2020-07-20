using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text playerHealthText;
    public Text enemyHealthText;
    public Text lostText;

    public int totalHp;
    public int playerHP;
    public int enemyHP;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = totalHp;
        enemyHP = totalHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHP > 0 || playerHP > 0 ){
            playerHealthText.text = playerHP + "/" + totalHp;
            enemyHealthText.text = enemyHP + "/" + totalHp;
        }


        if (playerHP <= 0)
        {
            lostText.text = totalHp.ToString( "You lost");
        }
        if (enemyHP <= 0)
        {
            lostText.text = totalHp.ToString( "You won");
        }

    }
}
