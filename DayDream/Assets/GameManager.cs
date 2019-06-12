using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaydreamElements.Common.IconMenu;
using DaydreamElements.ConstellationMenu;
using DaydreamElements.ObjectManipulation;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using jp.gulti.ColorBlind;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject completeLevelUI;
    public GameObject failedLevelUI;
    public GameObject instructionUI;
    public GameObject timerSlider;
    public GameObject sliderUI;
    public SliderScripts sliderTime;
    public GameObject uiCam;
    public GameObject hudCam;
    public GameObject mainCam;
    public GameObject introCam;
    public Text introText;

    public ConstellationMenuRoot menuRoot;
    public EffectManager effectManager;

    public bool gameOver;
    public bool sinkGame;
    public bool drawerGame;
    public bool cupboardGame;
    public bool gameStarted; // This variable allows me to control elements in scene to stop things from being interacted with too early
    bool win = false;
    private string introVCText;

    private MoveablePhysicsObject[] movableObjects;

    //These variables are for open day only
    public MainMenuScript mainMenu;
    public RestartMenu restartMenu;    
    private int levelNumber;
    public PostProcessVolume glaucomaLayer;
    public PostProcessVolume starburstsLayer;
    public PostProcessingBlur blur;
    public Material postprocessBlur;
    public ColorBlindnessSimulator colourblindSim;

    public GameObject sinkObject;
    private Vector3 startPosition;

    public Text objective;

    public Text levelText;
    public Text vcText;

    private IEnumerator gameTimer;
    private int conditionNumber;
    private int restartVariable;

    void Start()
    {
        colourblindSim.enabled = false;
        conditionNumber = 0;
        introVCText = "No Visual Condition";
        vcText.text = "Visual Condition Names";
        levelText.text = "Level Number";
        startPosition = sinkObject.transform.position;
        levelNumber = 1;
        gameStarted = false;
        gameOver = false;
        sinkGame = false;
        menuRoot.OnItemSelected.AddListener(OnItemSelected);
        sliderTime.enabled = false;

        movableObjects = (MoveablePhysicsObject[])GameObject.FindObjectsOfType(typeof(MoveablePhysicsObject));
        foreach (MoveablePhysicsObject movableObject in movableObjects)
        {
            movableObject.enabled = false;
        }        
    }

    public void SandboxMode()
    {
        foreach (MoveablePhysicsObject movableObject in movableObjects)
        {
            movableObject.enabled = true;
        }

        hudCam.SetActive(false);
        uiCam.SetActive(false);
    }

    void IntroScene()
    {
        introText.text = introVCText;
        introCam.SetActive(true);
        mainCam.SetActive(false);
        uiCam.SetActive(true);
        hudCam.SetActive(false);
        StartCoroutine(IntroWait(4));
    }
    void ExitIntroScene()
    {
        uiCam.SetActive(false);
        mainCam.SetActive(true);
        uiCam.SetActive(true);
        introCam.SetActive(false);
        hudCam.SetActive(true);
        StartRealGame();
    }

    public void StartGame()
    {
        IntroScene();
        vcText.text = "Visual Condition: No Visual Condition";
        levelText.text = "Level: 1";
    }

    void StartRealGame()
    {
        foreach (MoveablePhysicsObject movableObject in movableObjects)
        {
            movableObject.enabled = true;
        }        

        gameStarted = true;
        sinkGame = true;
        sliderTime.enabled = true;
        timerSlider.SetActive(true);
        instructionUI.SetActive(true);
        sliderUI.SetActive(true);
        gameTimer = SpawnCoroutine(10);
        StartCoroutine(gameTimer);
    }

    public void CompleteLevel()
    {
        win = true;
        gameOver = true;
        completeLevelUI.SetActive(true);
        RemoveUI();
        StopAllCoroutines();

        if (levelNumber < 7)
        {
            StartCoroutine(LevelWait());
        }
        else
        {
            WonGame();
        }
    }

    void NextLevel()
    {
        IEnumerator level;       
        win = false;
        gameOver = false;
        levelNumber += 1;
        sinkObject.transform.position = startPosition;

        SetNewVisualCondition();
        vcText.text = "Visual Condition: " + introVCText;
        levelText.text = "Level: " + levelNumber;        
        timerSlider.SetActive(true);
        level = SpawnCoroutine(10);
        sliderTime.Restart(10);
        level = SpawnCoroutine(10);
        ShowUI();
        SetVisualCondition();

        if (introVCText.Equals("Finished!"))
        {
            IntroScene();
            GameOver();
            sliderTime.enabled = false;
            sliderUI.SetActive(false);
            timerSlider.SetActive(false);
        }
        else
        {
            if (levelNumber == 2)
            {
                StopCoroutine(level);
                sliderTime.Restart(15);
                level = SpawnCoroutine(15);
                sinkGame = false;
                drawerGame = true;
                cupboardGame = false;
                objective.text = "Put object into Red Drawer under Sink";
                StartCoroutine(level);
            }
            else if (levelNumber == 3)
            {
                StopCoroutine(level);
                sliderTime.Restart(15);
                level = SpawnCoroutine(15);
                sinkGame = false;
                drawerGame = false;
                cupboardGame = true;
                objective.text = "Put object into Red Cupboard Behind You";
                StartCoroutine(level);
                conditionNumber += 1;
            }
            else if (levelNumber == 4)
            {
                levelNumber = 1;
                levelText.text = "Level: " + levelNumber;
                objective.text = "Put Object in Sink";
                StopCoroutine(level);
                RemoveUI();
                StartCoroutine(IntroWait(4));
                IntroScene();
            }
        }
        
    }

    void SetVisualCondition()
    {
        if (introVCText.Equals("No Visual Condition"))
        {
            colourblindSim.enabled = false;
            starburstsLayer.enabled = false;
            glaucomaLayer.enabled = false;
            blur.enabled = false;
        }
        else if (introVCText.Equals("Colour Blindness"))
        {
            colourblindSim.enabled = true;
            glaucomaLayer.enabled = false;
            starburstsLayer.enabled = false;
            blur.enabled = false;
        }
        else if (introVCText.Equals("Starbursts"))
        {
            colourblindSim.enabled = false;
            blur.enabled = false;
            glaucomaLayer.enabled = false;
            starburstsLayer.enabled = true;
            starburstsLayer.weight = 0.8f;
        }
        else if (introVCText.Equals("Glaucoma"))
        {
            colourblindSim.enabled = false;
            blur.enabled = false;
            starburstsLayer.enabled = false;
            glaucomaLayer.enabled = true;
            glaucomaLayer.weight = 0.31f;
        }
        else if (introVCText.Equals("Cataracts"))
        {
            colourblindSim.enabled = false;
            glaucomaLayer.enabled = false;
            starburstsLayer.enabled = false;
            blur.enabled = true;
            postprocessBlur.SetFloat("_BlurSize", 0.023f);
        }
    }

    void SetNewVisualCondition()
    {
        if (conditionNumber == 5)
        {
            introVCText = "Colour Blindness";
        }
        else if (conditionNumber == 2)
        {
            introVCText = "Starbursts";
        }
        else if (conditionNumber == 3)
        {
            introVCText = "Glaucoma";
        }
        else if (conditionNumber == 4)
        {
            introVCText = "Cataracts";
        }
        else if (conditionNumber == 1)
        {
            introVCText = "Finished!";            
        }
    }

    //This method is the original game code, used for open days.
    void OldNextLevel()
    {
        win = false;
        gameOver = false;
        ShowUI();
        levelNumber += 1;
        sinkObject.transform.position = startPosition;

        timerSlider.SetActive(true);

        if (levelNumber == 2) //Starbursts
        {
            introVCText = "Starbursts";
            sliderTime.Restart(10);            
            IEnumerator levelTwo = SpawnCoroutine(10);
            StartCoroutine(levelTwo);            
            starburstsLayer.enabled = true;
            starburstsLayer.weight = 0.8f;
            vcText.text = "Visual Condition: Starbursts";
            levelText.text = "Level: 2";
        }
        else if (levelNumber == 3) //Glaucoma
        {
            introVCText = "Glaucoma";
            sliderTime.Restart(10);
            sinkGame = false;
            drawerGame = true;            
            IEnumerator levelThree = SpawnCoroutine(10);
            StartCoroutine(levelThree);
            objective.text = "Put object into Drawer under Sink";
            starburstsLayer.enabled = false;
            glaucomaLayer.enabled = true;
            glaucomaLayer.weight = 0.31f;
            vcText.text = "Visual Condition: Glaucoma";
            levelText.text = "Level: 3";
        }
        else if (levelNumber == 4) //Cataracts
        {
            introVCText = "Cataracts";
            sliderTime.Restart(10);
            drawerGame = false;
            cupboardGame = true;
            IEnumerator levelFour = SpawnCoroutine(10);
            StartCoroutine(levelFour);
            objective.text = "Put object into Cupboard Behind You";
            glaucomaLayer.enabled = false;
            blur.enabled = true;
            postprocessBlur.SetFloat("_BlurSize", 0.02f);
            vcText.text = "Visual Condition: Cataracts";
            levelText.text = "Level: 4";
        }
        else if (levelNumber == 5) //Common - Glaucoma and Cataracts
        {
            sliderTime.Restart(10);
            IEnumerator levelFive = SpawnCoroutine(10);
            StartCoroutine(levelFive);
            glaucomaLayer.enabled = true;
            vcText.text = "Visual Conditions: Cataracts and Glaucoma";
            levelText.text = "Level: 5";
        }
        else if (levelNumber == 6) //Uncommon - Starbursts, Glaucoma and Cataracts
        {
            sliderTime.Restart(10);
            IEnumerator levelFive = SpawnCoroutine(10);
            StartCoroutine(levelFive);
            starburstsLayer.enabled = true;
            vcText.text = "Visual Condition: Cataracts, Glaucoma, Starbursts";
            levelText.text = "Level: 6";
        }
        else if (levelNumber == 7) //HARD - Starbursts, Glaucoma and Cataracts
        {
            sliderTime.Restart(10);
            IEnumerator levelFive = SpawnCoroutine(10);
            StartCoroutine(levelFive);
            starburstsLayer.weight = 0.9f;
            glaucomaLayer.weight = 0.45f;
            postprocessBlur.SetFloat("_BlurSize", 0.023f);
            vcText.text = "Visual Condition: Cataracts, Glaucoma, Starbursts *HARD*";
            levelText.text = "Level: 7";
        }
    }

    void WonGame()
    {
        sliderUI.SetActive(false);
        vcText.text = "Congrats!";
        levelText.text = "You completed the challenge!";
        starburstsLayer.enabled = false;
        glaucomaLayer.enabled = false;
        blur.enabled = false;
        sliderTime.enabled = false;
        timerSlider.SetActive(false);
        GameOver();
    }

    void GameOver()
    {
        restartMenu.ShowUI();
    }

    void EndGame()
    {
        gameOver = true;
        failedLevelUI.SetActive(true);
        RemoveUI();
        glaucomaLayer.enabled = false;
        blur.enabled = false;
        starburstsLayer.enabled = false;
        GameOver();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene        
    }

    void RemoveUI()
    {
        instructionUI.SetActive(false);
        timerSlider.SetActive(false);
        sliderUI.SetActive(false);
    }

    void ShowUI()
    {
        sliderUI.SetActive(true);
        completeLevelUI.SetActive(false);
        instructionUI.SetActive(true);
        timerSlider.SetActive(true);
    }

    private void OnItemSelected(ConstellationMenuItem item)
    {
        if (item.prefab == null)
        {
            effectManager.ConditionSelector(item.toolTip);
            return;
        }
    }

    IEnumerator SpawnCoroutine(int time)
    {
        yield return new WaitForSeconds(time); //wait 'time' amount seconds
        timerSlider.SetActive(false);
        if (!win)
        {
            EndGame();
        }
    }

    IEnumerator LevelWait()
    {
        yield return new WaitForSeconds(2.5f); //wait 5 seconds  
        NextLevel();
    }
    IEnumerator IntroWait(int time)
    {
        yield return new WaitForSeconds(time); //wait 5 seconds  
        ExitIntroScene();
    }
}
