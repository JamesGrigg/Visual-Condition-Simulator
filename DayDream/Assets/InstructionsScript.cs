using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsScript : MonoBehaviour
{
    public GameManager gameManager;
    public Text statusText;
    public GameObject continueButton;
    public GameObject skipButton;
    public GameObject replayButton;

    public GameObject slideOne;
    public GameObject slideTwo;
    public GameObject slideThree;
    public GameObject slideFour;
    public GameObject slideFive;
    public GameObject slideSix;

    private int slideNumber;

    // Start is called before the first frame update
    void Start()
    {
        slideNumber = 1;
        slideOne.SetActive(true);
    }

    public void RestartSlides()
    {
        slideNumber = 0;
        Continue();
        continueButton.SetActive(true);
        skipButton.SetActive(true);
        replayButton.SetActive(false);
    }
    
    public void Skip()
    {
        slideNumber = 5;
        Continue();        
    }

    public void Continue()
    {
        slideNumber += 1;

        if (slideNumber == 1)
        {
            slideOne.SetActive(true);
            slideTwo.SetActive(false);
            slideThree.SetActive(false);
            slideFour.SetActive(false);
            slideFive.SetActive(false);
            slideSix.SetActive(false);
        }
        if (slideNumber == 2)
        {
            slideOne.SetActive(false);
            slideTwo.SetActive(true);
            slideThree.SetActive(false);
            slideFour.SetActive(false);
            slideFive.SetActive(false);
            slideSix.SetActive(false);
        }
        else if (slideNumber == 3)
        {
            slideOne.SetActive(false);
            slideTwo.SetActive(false);
            slideThree.SetActive(true);
            slideFour.SetActive(false);
            slideFive.SetActive(false);
            slideSix.SetActive(false);
        }
        else if(slideNumber == 4)
        {
            slideOne.SetActive(false);
            slideTwo.SetActive(false);
            slideThree.SetActive(false);
            slideFour.SetActive(true);
            slideFive.SetActive(false);
            slideSix.SetActive(false);
        }
        else if (slideNumber == 5)
        {
            slideOne.SetActive(false);
            slideTwo.SetActive(false);
            slideThree.SetActive(false);
            slideFour.SetActive(false);
            slideFive.SetActive(true);
            slideSix.SetActive(false);
        }
        else if (slideNumber == 6)
        {
            slideOne.SetActive(false);
            slideTwo.SetActive(false);
            slideThree.SetActive(false);
            slideFour.SetActive(false);
            slideFive.SetActive(false);
            slideSix.SetActive(true);
            continueButton.SetActive(false);
            skipButton.SetActive(false);
            replayButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
