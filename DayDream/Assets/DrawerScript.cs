using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerScript : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject sinkObject;

    void OnTriggerEnter(Collider collision)
    {
        if (gameManager.gameOver == false && gameManager.drawerGame == true && collision.gameObject.tag == sinkObject.tag)
        {
            gameManager.CompleteLevel();
        }
    }
}
