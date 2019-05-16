using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerScript : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter()
    {
        if (gameManager.gameOver == false && gameManager.drawerGame == true)
        {
            gameManager.CompleteLevel();
        }
    }
}
