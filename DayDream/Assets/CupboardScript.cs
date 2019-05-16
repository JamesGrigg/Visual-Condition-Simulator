using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardScript : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter()
    {
        if (gameManager.gameOver == false && gameManager.cupboardGame == true)
        {
            gameManager.CompleteLevel();
        }
    }
}
