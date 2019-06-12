using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameManager gameManager;
    public Text statusText;
    public GameObject playButton;
    public GameObject sandboxButton;
    public GameObject backToMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void CheckPlay()
    {
        gameManager.StartGame();
        statusText.enabled = false;
        playButton.SetActive(false);
        sandboxButton.SetActive(false);
        backToMenu.SetActive(false);
    }

    public void CheckSandbox()
    {
        gameManager.SandboxMode();
        statusText.enabled = false;
        playButton.SetActive(false);
        sandboxButton.SetActive(false);
        backToMenu.SetActive(true);
    }

    public void BackToMenuButton()
    {
        Restart();
        gameManager.RestartGame();
    }

    public void Restart()
    {
        statusText.enabled = true;
        playButton.SetActive(true);
        sandboxButton.SetActive(true);
        backToMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
