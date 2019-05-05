using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartMenu : MonoBehaviour
{
    public GameManager gameManager;
    public Text statusText;
    public GameObject playButton;

    // Start is called before the first frame update
    void Start()
    {
        playButton.SetActive(false);
    }

    public void RestartPlay()
    {
        gameManager.RestartGame();
    }

    public void ShowUI()
    {
        playButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
