using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkTrigger : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter()
    {
        if (gameManager.gameOver == false && gameManager.sinkGame == true)
        {
            gameManager.CompleteLevel();
        }
    }
}
