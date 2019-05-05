using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameManager gameManager;
    public Text statusText;
    public GameObject playButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void CheckPlay()
    {
        gameManager.StartGame();
        statusText.enabled = false;
        playButton.SetActive(false);
    }

    public void Restart()
    {
        statusText.enabled = true;
        playButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
